using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookStoreWebApp.Model;
using Microsoft.Extensions.Options;

namespace BookStoreWebApp.Repository
{
    public class MessageRepository : IMessageRepository
    {
        // private  BookAlertConfig _newBookAlertConfig;
        private  readonly  IOptionsMonitor<BookAlertConfig> _newBookAlertConfig;

        public MessageRepository(IOptionsMonitor<BookAlertConfig> newBookAlertConfig)
        {
            _newBookAlertConfig = newBookAlertConfig;
            // _newBookAlertConfig = newBookAlertConfig.CurrentValue;
            // newBookAlertConfig.OnChange(config =>
            // {
            //     _newBookAlertConfig = config;
            // });
        }
        public string GetName()
        {
            return _newBookAlertConfig.CurrentValue.AppName;
        }
    }
}
