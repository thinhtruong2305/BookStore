﻿using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.Logic.Command.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class ChangeBookStatusHandler : IRequestHandler<ChangeBookStatusRequest, BaseCommandResult>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public ChangeBookStatusHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResult> Handle(ChangeBookStatusRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResult();

            try
            {
                var book = database.Books
                    .Where(b => b.Status != Status.Delete)
                    .FirstOrDefault(b => b.BookId == request.Id);

                var edition = database.Books
                    .Where(b => b.Status != Status.Delete)
                    .Select(b => b.Edition)
                    .FirstOrDefault(e => e.BookId == request.Id);

                var bookImages = database.BookImages
                    .Where(bi => (bi.Status != Status.Delete) && (bi.BookId == request.Id))
                    .ToList();

                if (book != null && edition != null && bookImages != null)
                {
                    var info = database.Infos
                        .Where(info => info.Status != Status.Delete)
                        .FirstOrDefault(info => info.InfoId == book.InfoId);
                    
                    if(info != null)
                    {
                        Status status = (book.Status == Status.Active) ? Status.InActive : Status.Active;

                        book.Status = status;
                        bookImages.ForEach(bi =>
                        {
                            bi.Status = status;
                        });
                        edition.Status = status;
                        info.Status = status;

                        book.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                        edition.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);
                        info.SetUpdateInfo(request.UserName ?? string.Empty, DateTime.Now);

                        database.Entry(book).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                        database.SaveChanges();

                        result.Success = true;
                    }
                }
                else
                {
                    result.Message = "Không thể thực hiện. Vui lòng kiểm tra lại id!";
                }
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
