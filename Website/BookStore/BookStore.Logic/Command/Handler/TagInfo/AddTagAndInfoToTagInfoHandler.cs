using AutoMapper;
using BookStore.Common.Shared.Model;
using BookStore.DAL;
using BookStore.DAL.Entities;
using BookStore.Logic.Command.Request;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Logic.Command.Handler
{
    public class AddTagAndInfoToTagInfoHandler : IRequestHandler<AddTagAndInfoToTagInfoRequest, BaseCommandResultWithData<TagInfo>>
    {
        private readonly AppDatabase database;
        private readonly IMapper mapper;

        public AddTagAndInfoToTagInfoHandler(AppDatabase database, IMapper mapper)
        {
            this.database = database;
            this.mapper = mapper;
        }
        public Task<BaseCommandResultWithData<TagInfo>> Handle(AddTagAndInfoToTagInfoRequest request, CancellationToken cancellationToken)
        {
            var result = new BaseCommandResultWithData<TagInfo>();

            try
            {
                var tagInfo = mapper.Map<TagInfo>(request);

                result.Data = database.TagInfos.Add(tagInfo);
                result.Success = true;
            }
            catch (Exception e)
            {
                result.Message = e.Message;
            }
            return Task.FromResult(result);
        }
    }
}
