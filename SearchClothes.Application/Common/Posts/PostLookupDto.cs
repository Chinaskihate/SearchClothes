using AutoMapper;
using SearchClothes.Application.Common.Mappings;
using SearchClothes.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchClothes.Application.Common.Posts
{
    public class PostLookupDto : IMapWith<Post>
    {
        public Guid Id { get; set; }

        public Guid CreatorId { get; set; }

        public string Title { get; set; }

        public string SellerLink { get; set; }

        public string Description { get; set; }

        public DateTime LastEditTime { get; set; }

        public double Rate { get; set; }

        public IList<Tag> Tags { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Post, PostLookupDto>()
                .ForMember(postDto => postDto.Id,
                opt => opt.MapFrom(post => post.Id))
                .ForMember(postDto => postDto.CreatorId,
                opt => opt.MapFrom(post => post.CreatorId))
                .ForMember(postDto => postDto.Title,
                opt => opt.MapFrom(post => post.Title))
                .ForMember(postDto => postDto.SellerLink,
                opt => opt.MapFrom(post => post.SellerLink))
                .ForMember(postDto => postDto.Description,
                opt => opt.MapFrom(post => post.Description))
                .ForMember(postDto => postDto.LastEditTime,
                opt => opt.MapFrom(post => post.LastEditTime))
                .ForMember(postDto => postDto.Rate,
                opt => opt.MapFrom(
                    post => post.Rates.Count() == 0 ? 0 : post.Rates.Average(r => r.Value)
                    ))
                .ForMember(postDto => postDto.Tags,
                opt => opt.MapFrom(post => post.Tags));
        }
    }
}
