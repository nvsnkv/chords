using System;
using System.Data.Odbc;
using System.Security.Claims;
using System.Security.Principal;
using Chords.Domain.Contract;
using Chords.Domain.Contract.Data;

namespace Chords.Server.Models
{
    internal sealed class Owner : IUser
    {
        private Owner(string id, string email, string phone)
        {
            Id = id;
            Email = email;
            Phone = phone;
        }

        public string Id { get; }

        public string Email { get; }

        public string Phone { get; }

        public static IUser FromPrincipal(ClaimsPrincipal principal)
        {
            if (principal == null) throw new ArgumentNullException(nameof(principal));

            var id = principal.FindFirst("sub") ?? throw new ArgumentNullException($"principal.FindFirst(\"sub\")");
            var email = principal.FindFirst("email")?.Value;
            var phone = principal.FindFirst("phone")?.Value;

            return new Owner(id.Value, email, phone);
        }
    }
}