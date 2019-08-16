﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Shamane.Domain
{
    public class UserToken
    {
        public int Id { get; set; }

        public string AccessTokenHash { get; set; }

        public DateTimeOffset AccessTokenExpiresDateTime { get; set; }

        public string RefreshTokenIdHash { get; set; }

        public string RefreshTokenIdHashSource { get; set; }

        public DateTimeOffset RefreshTokenExpiresDateTime { get; set; }

        public Guid UserId { get; set; }
        public virtual User User { get; set; }
    }
}
