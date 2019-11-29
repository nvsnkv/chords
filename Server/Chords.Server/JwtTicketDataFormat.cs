using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Chords.Server
{
    internal class JwtTicketDataFormat : ISecureDataFormat<AuthenticationTicket>
    {
        private readonly string _issuer;

        private readonly string _audience;
        
        private readonly SigningCredentials _credentials;

        private readonly JwtSecurityTokenHandler _handler;

        private readonly TokenValidationParameters _validationParams;

        public JwtTicketDataFormat(IConfiguration configuration)
        {
            _issuer = configuration["Authentication:JWT:Issuer"];
            _audience = configuration["Authentication:JWT:Audience"];
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Authentication:JWT:Key"]));
            _credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            _handler = new JwtSecurityTokenHandler();
            _validationParams = new TokenValidationParameters()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = key,
                ValidateIssuer = true,
                ValidIssuer = _issuer,
                ValidateAudience = true,
                ValidAudience = _audience
            };
        }

        public string Protect(AuthenticationTicket data) => Protect(data, null);

        public string Protect(AuthenticationTicket data, string purpose)
        {
            var notBefore = data.Properties.IssuedUtc?.DateTime.Add((TimeSpan)data.Properties.IssuedUtc?.Offset);
            var expires = data.Properties.ExpiresUtc?.DateTime.Add((TimeSpan)data.Properties.ExpiresUtc?.Offset);

            var token = new JwtSecurityToken(_issuer, _audience, data.Principal.Claims, notBefore, expires, _credentials);

            return _handler.WriteToken(token);
        }

        public AuthenticationTicket Unprotect(string protectedText) => Unprotect(protectedText, null);

        public AuthenticationTicket Unprotect(string protectedText, string purpose)
        {
            ClaimsPrincipal principal;
            SecurityToken validToken;

            try
            {
                principal = _handler.ValidateToken(protectedText, _validationParams, out validToken);
            }
            catch (SecurityTokenValidationException)
            {
                return null;
            }

            if (validToken == null || principal == null)
            {
                return null;
            }

            return new AuthenticationTicket(principal, CookieAuthenticationDefaults.AuthenticationScheme);
        }
    }
}