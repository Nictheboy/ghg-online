﻿using LiteDB;
using server.Entities;
using static server.Entities.AccountLog;

namespace server.Services.Database
{
    public class AccountLogger : IAccountLogger
    {
        private readonly ILiteCollection<AccountLog> _accountLogs;
        public AccountLogger(IDbHolder dbHolder)
        {
            _accountLogs = dbHolder.DbAccountServiceLog.GetCollection<AccountLog>();
        }
        public void WriteLog(AccountLogType type, string? ip, string? userName, bool success, string? appendix)
        {
            _accountLogs.Insert(new AccountLog
            {
                Type = type,
                Time = DateTime.Now,
                Ip = ip,
                UserName = userName,
                Success = success,
                Appendix = appendix
            });
        }
    }
}
