using AutoMapper;
using SchoolRegister.DAL.Entities;
using SchoolRegister.Domain.Helpers;
using SchoolRegister.Domain.ViewModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolRegister.Domain.Profiles
{
	public class StudentsProfile : Profile
	{
		public StudentsProfile()
		{
			CreateMap<Student, StudentViewModel>()
				.ForMember(
				dest => dest.FullName,
				opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
				//.ForMember(
				//	dest => dest.LevelName,
				//	opt =>opt.))
				.ForMember(
				dest => dest.Age,
				opt => opt.MapFrom(src => src.DateOfBirth.GetCurrentAge()));

			CreateMap<StudentCreationViewModel, Student>();

		}
	}
}
