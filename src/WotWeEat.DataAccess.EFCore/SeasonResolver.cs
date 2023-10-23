using AutoMapper;
using System;
using WotWeEat.Domain.Enum;

namespace WotWeEat.DataAccess.EFCore
{
    internal class SeasonResolver : IValueResolver<List<Season>, Season?, Season>, IValueConverter<List<Season>, Season?>, IValueConverter<Season?, List<Season>>
    {

        public Season? Convert(List<Season> sourceMember, ResolutionContext context)
        {
            Season? selectedSeasons = 0;

            foreach (var season in sourceMember)
            {
                selectedSeasons |= season;
            }

            return selectedSeasons;
        }

        public Season Resolve(List<Season> source, Season? destination, Season destMember, ResolutionContext context)
        {
            Season selectedSeasons = 0;

            foreach (var season in source)
            {
                selectedSeasons |= season;
            }

            return selectedSeasons;
        }

        public List<Season> Convert(Season? sourceMember, ResolutionContext context)
        {

            if (sourceMember == null)
            {
                return new List<Season>();
            }
            var result = new List<Season>();
            var values = Enum.GetValues(typeof(Season)).Cast<Season>();

            foreach (var value in values)
            {
                if (sourceMember.Value.HasFlag(value))
                {
                    result.Add(value);
                }
            }

            return result;
        }
    }
}
