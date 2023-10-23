using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WotWeEat.DataAccess.EFCore.Test
{
    internal static  class AutomapperTestHelper
    {
        public static IMapper GetAutomapper()
        {
            //auto mapper configuration
            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new MappingProfile()); //your automapperprofile 
            });
            return mockMapper.CreateMapper();
        }
    }
}
