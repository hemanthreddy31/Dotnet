﻿using DotNet8WebAPI.Model;

namespace DotNet8WebAPI.Services
{
    public class OurHeroService : IOurHeroService
    {
        private readonly List<OurHero> _ourHeroesList;

        public OurHeroService()
        {
            _ourHeroesList = new List<OurHero>()
            {
                new OurHero()
                {
                    Id=1,
                    FirstName="Test",
                    LastName="Test",
                    isActive=true,
                }
            };
        }
        public List<OurHero> GetAllHeros(bool? isActive)
        {
            return isActive == null ? _ourHeroesList : _ourHeroesList.Where(hero => hero.isActive == isActive).ToList();
        }

        public bool DeleteHerosById(int id)
        {
            var ourHeroIndex= _ourHeroesList.FindIndex(index=>index.Id==id);
            if (ourHeroIndex >= 0)
            {
                _ourHeroesList.RemoveAt(ourHeroIndex);
            }
            return ourHeroIndex >= 0;
        }

        public OurHero AddOurHero(AddUpdateOurHero obj)
        {
            var addHero = new OurHero()
            {
                Id = _ourHeroesList.Max(hero => hero.Id) + 1,
                FirstName = obj.FirstName,
                LastName = obj.LastName,
                isActive = obj.isActive,
            };
            _ourHeroesList.Add(addHero);
            return addHero;
        } 

        public OurHero? GetHeroById(int id)
        {
            return _ourHeroesList.FirstOrDefault(hero=>hero.Id== id);
        }

        public OurHero? UpdateOurHero(int id, AddUpdateOurHero obj)
        {
            var ourHeroIndex=_ourHeroesList.FindIndex(index=>index.Id== id);
            if (ourHeroIndex >= 0)
            {
                var hero = _ourHeroesList[ourHeroIndex];
                hero.FirstName = obj.FirstName;
                hero.LastName = obj.LastName;
                hero.isActive = obj.isActive;
                _ourHeroesList[ourHeroIndex] = hero;
                return hero;
            }
            else
            {
                return null;
            }
        }
    }
}
