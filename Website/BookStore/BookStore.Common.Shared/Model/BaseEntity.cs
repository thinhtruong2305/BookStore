using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Common.Shared.Model
{
    public class BaseEntity
    {
        public string? CreateBy { get; set; }
        public DateTime? CreateAt { get; set; }
        public string? UpdateBy { get; set; }
        public DateTime? UpdateAt { get; set; }
        public Status Status { get; set; }

        public BaseEntity SetCreateInfo(string userName, DateTime date)
        {
            this.CreateAt = date;
            this.CreateBy = userName;
            return this;
        }
        public BaseEntity SetUpdateInfo(string user, DateTime date)
        {
            this.UpdateBy = user;
            this.UpdateAt = date;
            return this;
        }

        public BaseEntity MarkAsDelete(string user, DateTime date)
        {
            this.Status = Status.Delete;
            this.UpdateBy = user;
            this.UpdateAt = date;
            return this;
        }
    }
}
