﻿using System.Collections.Generic;
using System.Linq;
using Domain.Context;
using Domain.Entities.Growing;

namespace Domain.Filldatabase
{
    public partial class FirstFill
    {
        private static readonly DatabaseContext Context = DatabaseContext.Create();

        // First fill the database.
        public static void NewFirstFillDataBase()
        {
            GrowingDatabaseFill();
            BreedingDatabaseFill();
        }

        private static void GrowingDatabaseFill()
        {
            var growingtypes = new List<GrowingType>
            {
                new GrowingType {Name = "Bergamot"},
                new GrowingType {Name = "Bread"},
                new GrowingType {Name = "Crataegu"},
                new GrowingType {Name = "Finik"},
                new GrowingType {Name = "Fodder"},
                new GrowingType {Name = "Forage"},
                new GrowingType {Name = "Kepel"},
                new GrowingType {Name = "Leguminous"},
                new GrowingType {Name = "Melon"},
                new GrowingType {Name = "Olive"},
                new GrowingType {Name = "Silage"},
                new GrowingType {Name = "Spicy"},
                new GrowingType {Name = "Strawberry"},
                new GrowingType {Name = "Tern"},
                new GrowingType {Name = "Tuber"}
            };

            foreach (var item in growingtypes) Context.GrowingTypes.Add(item);
            Context.SaveChanges();

            var growingtype1 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Bergamot");
            var growingtype2 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Bread");
            var growingtype3 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Crataegu");
            var growingtype4 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Finik");
            var growingtype5 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Fodder");
            var growingtype6 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Forage");
            var growingtype7 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Kepel");
            var growingtype8 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Leguminous");
            var growingtype9 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Melon");
            var growingtype10 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Olive");
            var growingtype11 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Silage");
            var growingtype12 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Spicy");
            var growingtype13 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Strawberry");
            var growingtype14 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Tern");
            var growingtype15 = Context.GrowingTypes.FirstOrDefault(n => n.Name == "Tuber");
            var growingcultures = new List<GrowingCultures>
            {
                new GrowingCultures {Name = "Абрикос", GrowingType = growingtype1},
                new GrowingCultures {Name = "Абрикос японский", GrowingType = growingtype1},
                new GrowingCultures {Name = "Авара", GrowingType = growingtype1},
                new GrowingCultures {Name = "Авокадо", GrowingType = growingtype1},
                new GrowingCultures {Name = "Азимина трёхлопастная", GrowingType = growingtype1},
                new GrowingCultures {Name = "Айва", GrowingType = growingtype1},
                new GrowingCultures {Name = "Айва китайская", GrowingType = growingtype1},
                new GrowingCultures {Name = "Алыча", GrowingType = growingtype1},
                new GrowingCultures {Name = "Амазонский виноград", GrowingType = growingtype1},
                new GrowingCultures {Name = "Аннона сенегальская", GrowingType = growingtype1},
                new GrowingCultures {Name = "Антильский крыжовник", GrowingType = growingtype1},
                new GrowingCultures {Name = "Апельсин", GrowingType = growingtype1},
                new GrowingCultures {Name = "Араза", GrowingType = growingtype1},
                new GrowingCultures {Name = "Бабако", GrowingType = growingtype1},
                new GrowingCultures {Name = "Баиль", GrowingType = growingtype1},
                new GrowingCultures {Name = "Белая сапота", GrowingType = growingtype1},
                new GrowingCultures {Name = "Бергамот", GrowingType = growingtype1},
                new GrowingCultures {Name = "Бигнай", GrowingType = growingtype1},
                new GrowingCultures {Name = "Бирманский виноград", GrowingType = growingtype1},
                new GrowingCultures {Name = "Боярышник азароль", GrowingType = growingtype1},
                new GrowingCultures {Name = "Боярышник понтийский", GrowingType = growingtype1},
                new GrowingCultures {Name = "Боярышник тёмно-кровавый", GrowingType = growingtype1},
                new GrowingCultures {Name = "Вампи", GrowingType = growingtype1},
                new GrowingCultures {Name = "Вишня", GrowingType = growingtype1},
                new GrowingCultures {Name = "Вишня вишнеобразная", GrowingType = growingtype1},
                new GrowingCultures {Name = "Вишня колокольчатая", GrowingType = growingtype1},
                new GrowingCultures {Name = "Вишня мелкопильчатая", GrowingType = growingtype1},
                new GrowingCultures {Name = "Вишня обыкновенная", GrowingType = growingtype1},
                new GrowingCultures {Name = "Водяное яблоко", GrowingType = growingtype1},
                new GrowingCultures {Name = "Горная папайя", GrowingType = growingtype1},
                new GrowingCultures {Name = "Гранат", GrowingType = growingtype1},
                new GrowingCultures {Name = "Грейпфрут", GrowingType = growingtype1},
                new GrowingCultures {Name = "Грумичама", GrowingType = growingtype1},
                new GrowingCultures {Name = "Груша грушелистная", GrowingType = growingtype1},
                new GrowingCultures {Name = "Груша обыкновенная", GrowingType = growingtype1},
                new GrowingCultures {Name = "Джамболан", GrowingType = growingtype1},
                new GrowingCultures {Name = "Джекфрут", GrowingType = growingtype1},
                new GrowingCultures {Name = "Дуриан цибетиновый", GrowingType = growingtype1},
                new GrowingCultures {Name = "Дюки", GrowingType = growingtype1},
                new GrowingCultures {Name = "Жаботикаба", GrowingType = growingtype1},
                new GrowingCultures {Name = "Земляничное дерево красное", GrowingType = growingtype1},
                new GrowingCultures {Name = "Земляничное дерево крупноплодное", GrowingType = growingtype1},
                new GrowingCultures {Name = "Земляничное дерево Менциса", GrowingType = growingtype1},
                new GrowingCultures {Name = "Инжир", GrowingType = growingtype1},
                new GrowingCultures {Name = "Амарант", GrowingType = growingtype2},
                new GrowingCultures {Name = "Гречиха", GrowingType = growingtype2},
                new GrowingCultures {Name = "Дагусса", GrowingType = growingtype2},
                new GrowingCultures {Name = "Кукуруза", GrowingType = growingtype2},
                new GrowingCultures {Name = "Могар", GrowingType = growingtype2},
                new GrowingCultures {Name = "Овёс", GrowingType = growingtype2},
                new GrowingCultures {Name = "Пайза", GrowingType = growingtype2},
                new GrowingCultures {Name = "Полба", GrowingType = growingtype2},
                new GrowingCultures {Name = "Просо", GrowingType = growingtype2},
                new GrowingCultures {Name = "Пшеница", GrowingType = growingtype2},
                new GrowingCultures {Name = "Рис", GrowingType = growingtype2},
                new GrowingCultures {Name = "Рожь", GrowingType = growingtype2},
                new GrowingCultures {Name = "Сорго", GrowingType = growingtype2},
                new GrowingCultures {Name = "Чумиза", GrowingType = growingtype2},
                new GrowingCultures {Name = "Ячмень", GrowingType = growingtype2},
                new GrowingCultures {Name = "Квиноа", GrowingType = growingtype2},
                new GrowingCultures {Name = "Айва японская", GrowingType = growingtype3},
                new GrowingCultures {Name = "Актинидия коломикта", GrowingType = growingtype3},
                new GrowingCultures {Name = "Арония Мичурина", GrowingType = growingtype3},
                new GrowingCultures {Name = "Арония черноплодная", GrowingType = growingtype3},
                new GrowingCultures {Name = "Барбарис обыкновенный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Боярышник кроваво-красный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Боярышник крупноплодный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Боярышник мексиканский", GrowingType = growingtype3},
                new GrowingCultures {Name = "Боярышник обыкновенный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Боярышник перистонадрезанный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Виноград амурский", GrowingType = growingtype3},
                new GrowingCultures {Name = "Виноград культурный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Вишня войлочная", GrowingType = growingtype3},
                new GrowingCultures {Name = "Вишня кустарниковая", GrowingType = growingtype3},
                new GrowingCultures {Name = "Голубика", GrowingType = growingtype3},
                new GrowingCultures {Name = "Голубика высокорослая", GrowingType = growingtype3},
                new GrowingCultures {Name = "Гранат обыкновенный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Гуарана", GrowingType = growingtype3},
                new GrowingCultures {Name = "Ежевика", GrowingType = growingtype3},
                new GrowingCultures {Name = "Ежевика вязолистная", GrowingType = growingtype3},
                new GrowingCultures {Name = "Ежевика гигантская", GrowingType = growingtype3},
                new GrowingCultures {Name = "Ежевика медвежья", GrowingType = growingtype3},
                new GrowingCultures {Name = "Ежевика обыкновенная", GrowingType = growingtype3},
                new GrowingCultures {Name = "Киви", GrowingType = growingtype3},
                new GrowingCultures {Name = "Кизил обыкновенный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Кокона", GrowingType = growingtype3},
                new GrowingCultures {Name = "Крыжовник обыкновенный", GrowingType = growingtype3},
                new GrowingCultures {Name = "Рамбутан", GrowingType = growingtype4},
                new GrowingCultures {Name = "Ренклод", GrowingType = growingtype4},
                new GrowingCultures {Name = "Рожковое дерево", GrowingType = growingtype4},
                new GrowingCultures {Name = "Розовое яблоко", GrowingType = growingtype4},
                new GrowingCultures {Name = "Рябина обыкновенная", GrowingType = growingtype4},
                new GrowingCultures {Name = "Рябина обыкновенная (Дочь Кубовой)", GrowingType = growingtype4},
                new GrowingCultures {Name = "Рябина сибирская", GrowingType = growingtype4},
                new GrowingCultures {Name = "Салак", GrowingType = growingtype4},
                new GrowingCultures {Name = "Сахарное яблоко", GrowingType = growingtype4},
                new GrowingCultures {Name = "Сизигиум масляный", GrowingType = growingtype4},
                new GrowingCultures {Name = "Сикомор", GrowingType = growingtype4},
                new GrowingCultures {Name = "Слива", GrowingType = growingtype4},
                new GrowingCultures {Name = "Слива домашняя", GrowingType = growingtype4},
                new GrowingCultures {Name = "Слива китайская", GrowingType = growingtype4},
                new GrowingCultures {Name = "Сметанное яблоко", GrowingType = growingtype4},
                new GrowingCultures {Name = "Суринамская вишня", GrowingType = growingtype4},
                new GrowingCultures {Name = "Тамарилло", GrowingType = growingtype4},
                new GrowingCultures {Name = "Тамаринд", GrowingType = growingtype4},
                new GrowingCultures {Name = "Фейхоа", GrowingType = growingtype4},
                new GrowingCultures {Name = "Финик пальчатый", GrowingType = growingtype4},
                new GrowingCultures {Name = "Фисташка настоящая", GrowingType = growingtype4},
                new GrowingCultures {Name = "Хлебное дерево", GrowingType = growingtype4},
                new GrowingCultures {Name = "Хурма восточная", GrowingType = growingtype4},
                new GrowingCultures {Name = "Хурма кавказская", GrowingType = growingtype4},
                new GrowingCultures {Name = "Хурма мушмуловидная", GrowingType = growingtype4},
                new GrowingCultures {Name = "Цитрон", GrowingType = growingtype4},
                new GrowingCultures {Name = "Цитрон пальчатый", GrowingType = growingtype4},
                new GrowingCultures {Name = "Черёмуха виргинская", GrowingType = growingtype4},
                new GrowingCultures {Name = "Черёмуха обыкновенная", GrowingType = growingtype4},
                new GrowingCultures {Name = "Черёмуха пенсильванская", GrowingType = growingtype4},
                new GrowingCultures {Name = "Черёмуха поздняя", GrowingType = growingtype4},
                new GrowingCultures {Name = "Черешня", GrowingType = growingtype4},
                new GrowingCultures {Name = "Черимойя", GrowingType = growingtype4},
                new GrowingCultures {Name = "Чёрная сапота", GrowingType = growingtype4},
                new GrowingCultures {Name = "Шелковица белая", GrowingType = growingtype4},
                new GrowingCultures {Name = "Шелковица чёрная", GrowingType = growingtype4},
                new GrowingCultures {Name = "Ши(дерево)", GrowingType = growingtype4},
                new GrowingCultures {Name = "Юдзу", GrowingType = growingtype4},
                new GrowingCultures {Name = "Яблоня домашняя", GrowingType = growingtype4},
                new GrowingCultures {Name = "Ятоба", GrowingType = growingtype4},
                new GrowingCultures {Name = "Кормовая свёкла", GrowingType = growingtype5},
                new GrowingCultures {Name = "Сахарная свёкла", GrowingType = growingtype5},
                new GrowingCultures {Name = "Брюква", GrowingType = growingtype5},
                new GrowingCultures {Name = "Кормовая морковь", GrowingType = growingtype5},
                new GrowingCultures {Name = "Турнепс", GrowingType = growingtype5},
                new GrowingCultures {Name = "Кормовой картофель", GrowingType = growingtype5},
                new GrowingCultures {Name = "Топинамбур", GrowingType = growingtype5},
                new GrowingCultures {Name = "Кормовой арбуз", GrowingType = growingtype5},
                new GrowingCultures {Name = "Кабачок", GrowingType = growingtype5},
                new GrowingCultures {Name = "Тыква", GrowingType = growingtype5},
                new GrowingCultures {Name = "Овёс", GrowingType = growingtype6},
                new GrowingCultures {Name = "Ячмень", GrowingType = growingtype6},
                new GrowingCultures {Name = "Кукуруза", GrowingType = growingtype6},
                new GrowingCultures {Name = "Сорго", GrowingType = growingtype6},
                new GrowingCultures {Name = "Чумиза", GrowingType = growingtype6},
                new GrowingCultures {Name = "Африканское просо", GrowingType = growingtype6},
                new GrowingCultures {Name = "Горох", GrowingType = growingtype6},
                new GrowingCultures {Name = "Боб конский", GrowingType = growingtype6},
                new GrowingCultures {Name = "Вика", GrowingType = growingtype6},
                new GrowingCultures {Name = "Пелюшка", GrowingType = growingtype6},
                new GrowingCultures {Name = "Люпин кормовой", GrowingType = growingtype6},
                new GrowingCultures {Name = "Какао", GrowingType = growingtype7},
                new GrowingCultures {Name = "Каламондин", GrowingType = growingtype7},
                new GrowingCultures {Name = "Канариум филиппинский", GrowingType = growingtype7},
                new GrowingCultures {Name = "Капулин", GrowingType = growingtype7},
                new GrowingCultures {Name = "Карамбола", GrowingType = growingtype7},
                new GrowingCultures {Name = "Кафрская слива", GrowingType = growingtype7},
                new GrowingCultures {Name = "Каштан американский", GrowingType = growingtype7},
                new GrowingCultures {Name = "Каштан Генри", GrowingType = growingtype7},
                new GrowingCultures {Name = "Каштан городчатый", GrowingType = growingtype7},
                new GrowingCultures {Name = "Каштан мягчайший", GrowingType = growingtype7},
                new GrowingCultures {Name = "Каштан посевной", GrowingType = growingtype7},
                new GrowingCultures {Name = "Каштан Сегю", GrowingType = growingtype7},
                new GrowingCultures {Name = "Кепел", GrowingType = growingtype7},
                new GrowingCultures {Name = "Кешью", GrowingType = growingtype7},
                new GrowingCultures {Name = "Клубничное дерево", GrowingType = growingtype7},
                new GrowingCultures {Name = "Кокосовая пальма", GrowingType = growingtype7},
                new GrowingCultures {Name = "Конфетное дерево", GrowingType = growingtype7},
                new GrowingCultures {Name = "Кофе аравийский", GrowingType = growingtype7},
                new GrowingCultures {Name = "Кофе конголезский", GrowingType = growingtype7},
                new GrowingCultures {Name = "Кумкват", GrowingType = growingtype7},
                new GrowingCultures {Name = "Купуасу", GrowingType = growingtype7},
                new GrowingCultures {Name = "Лайм", GrowingType = growingtype7},
                new GrowingCultures {Name = "Лещина древовидная", GrowingType = growingtype7},
                new GrowingCultures {Name = "Лимон", GrowingType = growingtype7},
                new GrowingCultures {Name = "Личи", GrowingType = growingtype7},
                new GrowingCultures {Name = "Макадамия", GrowingType = growingtype7},
                new GrowingCultures {Name = "Малайское яблоко", GrowingType = growingtype7},
                new GrowingCultures {Name = "Манго индийское", GrowingType = growingtype7},
                new GrowingCultures {Name = "Мандарин", GrowingType = growingtype7},
                new GrowingCultures {Name = "Мандарин уншиу", GrowingType = growingtype7},
                new GrowingCultures {Name = "Мирциария сомнительная", GrowingType = growingtype7},
                new GrowingCultures {Name = "Мускатник душистый", GrowingType = growingtype7},
                new GrowingCultures {Name = "Мушмула германская", GrowingType = growingtype7},
                new GrowingCultures {Name = "Мушмула японская", GrowingType = growingtype7},
                new GrowingCultures {Name = "Олива европейская", GrowingType = growingtype7},
                new GrowingCultures {Name = "Оранжекват", GrowingType = growingtype7},
                new GrowingCultures {Name = "Орех айлантолистный", GrowingType = growingtype7},
                new GrowingCultures {Name = "Орех грецкий", GrowingType = growingtype7},
                new GrowingCultures {Name = "Орех маньчжурский", GrowingType = growingtype7},
                new GrowingCultures {Name = "Пальчиковый лайм", GrowingType = growingtype7},
                new GrowingCultures {Name = "Папайя", GrowingType = growingtype7},
                new GrowingCultures {Name = "Пекан обыкновенный", GrowingType = growingtype7},
                new GrowingCultures {Name = "Персик", GrowingType = growingtype7},
                new GrowingCultures {Name = "Помело", GrowingType = growingtype7},
                new GrowingCultures {Name = "Померанец", GrowingType = growingtype7},
                new GrowingCultures {Name = "Боб обыкновенный", GrowingType = growingtype8},
                new GrowingCultures {Name = "Горох", GrowingType = growingtype8},
                new GrowingCultures {Name = "Люпин", GrowingType = growingtype8},
                new GrowingCultures {Name = "Фасоль", GrowingType = growingtype8},
                new GrowingCultures {Name = "Боб соевый", GrowingType = growingtype8},
                new GrowingCultures {Name = "Горошек(вика)", GrowingType = growingtype8},
                new GrowingCultures {Name = "Боб мунг", GrowingType = growingtype8},
                new GrowingCultures {Name = "Чечевица", GrowingType = growingtype8},
                new GrowingCultures {Name = "Турецкий горох", GrowingType = growingtype8},
                new GrowingCultures {Name = "Чина", GrowingType = growingtype8},
                new GrowingCultures {Name = "Лук", GrowingType = growingtype9},
                new GrowingCultures {Name = "Чеснок", GrowingType = growingtype9},
                new GrowingCultures {Name = "Томат", GrowingType = growingtype9},
                new GrowingCultures {Name = "Перец овощной", GrowingType = growingtype9},
                new GrowingCultures {Name = "Баклажан", GrowingType = growingtype9},
                new GrowingCultures {Name = "Тыква", GrowingType = growingtype9},
                new GrowingCultures {Name = "Кабачок", GrowingType = growingtype9},
                new GrowingCultures {Name = "Огурец", GrowingType = growingtype9},
                new GrowingCultures {Name = "Патиссон", GrowingType = growingtype9},
                new GrowingCultures {Name = "Дыня", GrowingType = growingtype9},
                new GrowingCultures {Name = "Арбуз", GrowingType = growingtype9},
                new GrowingCultures {Name = "Артишок", GrowingType = growingtype9},
                new GrowingCultures {Name = "Спаржа", GrowingType = growingtype9},
                new GrowingCultures {Name = "Ревень", GrowingType = growingtype9},
                new GrowingCultures {Name = "Кешью", GrowingType = growingtype10},
                new GrowingCultures {Name = "Фисташка настоящая", GrowingType = growingtype10},
                new GrowingCultures {Name = "Артишок испанский", GrowingType = growingtype10},
                new GrowingCultures {Name = "Подсолнечник однолетни", GrowingType = growingtype10},
                new GrowingCultures {Name = "Арахис культурный", GrowingType = growingtype10},
                new GrowingCultures {Name = "Виноград культурный", GrowingType = growingtype10},
                new GrowingCultures {Name = "Кукуруза сахарная", GrowingType = growingtype10},
                new GrowingCultures {Name = "Рапс", GrowingType = growingtype10},
                new GrowingCultures {Name = "Сурепица", GrowingType = growingtype10},
                new GrowingCultures {Name = "Горчица", GrowingType = growingtype10},
                new GrowingCultures {Name = "Рыжик посевной", GrowingType = growingtype10},
                new GrowingCultures {Name = "Смородина чёрная", GrowingType = growingtype10},
                new GrowingCultures {Name = "Авокадо", GrowingType = growingtype10},
                new GrowingCultures {Name = "Лён обыкновенный", GrowingType = growingtype10},
                new GrowingCultures {Name = "Хлопчатник", GrowingType = growingtype10},
                new GrowingCultures {Name = "Какао", GrowingType = growingtype10},
                new GrowingCultures {Name = "Кофе аравийский", GrowingType = growingtype10},
                new GrowingCultures {Name = "Олива европейска", GrowingType = growingtype10},
                new GrowingCultures {Name = "Тунг", GrowingType = growingtype10},
                new GrowingCultures {Name = "Клещевина обыкновенная", GrowingType = growingtype10},
                new GrowingCultures {Name = "Орех грецкий", GrowingType = growingtype10},
                new GrowingCultures {Name = "Баланитес", GrowingType = growingtype10},
                new GrowingCultures {Name = "Кунжут индийский", GrowingType = growingtype10},
                new GrowingCultures {Name = "Миндаль", GrowingType = growingtype10},
                new GrowingCultures {Name = "Аргания колючая", GrowingType = growingtype10},
                new GrowingCultures {Name = "Пиния", GrowingType = growingtype10},
                new GrowingCultures {Name = "Сибирский кедр", GrowingType = growingtype10},
                new GrowingCultures {Name = "Чай", GrowingType = growingtype10},
                new GrowingCultures {Name = "Ляллеманция", GrowingType = growingtype10},
                new GrowingCultures {Name = "Перилла", GrowingType = growingtype10},
                new GrowingCultures {Name = "Кукуруза", GrowingType = growingtype11},
                new GrowingCultures {Name = "Подсолнечник", GrowingType = growingtype11},
                new GrowingCultures {Name = "Кормовая капуста", GrowingType = growingtype11},
                new GrowingCultures {Name = "Топинамбур", GrowingType = growingtype11},
                new GrowingCultures {Name = "Горчица белая", GrowingType = growingtype11},
                new GrowingCultures {Name = "Рапс озимый", GrowingType = growingtype11},
                new GrowingCultures {Name = "Сорго", GrowingType = growingtype11},
                new GrowingCultures {Name = "Kапуста белокочанная", GrowingType = growingtype12},
                new GrowingCultures {Name = "Капуста краснокочанная", GrowingType = growingtype12},
                new GrowingCultures {Name = "Капуста савойская", GrowingType = growingtype12},
                new GrowingCultures {Name = "Капуста брюссельская", GrowingType = growingtype12},
                new GrowingCultures {Name = "Капуста цветная", GrowingType = growingtype12},
                new GrowingCultures {Name = "Капуста кольраби", GrowingType = growingtype12},
                new GrowingCultures {Name = "Капуста брокколи", GrowingType = growingtype12},
                new GrowingCultures {Name = "Салат", GrowingType = growingtype12},
                new GrowingCultures {Name = "Укроп", GrowingType = growingtype12},
                new GrowingCultures {Name = "Эстрагон", GrowingType = growingtype12},
                new GrowingCultures {Name = "Чабер", GrowingType = growingtype12},
                new GrowingCultures {Name = "Базилик", GrowingType = growingtype12},
                new GrowingCultures {Name = "Майоран", GrowingType = growingtype12},
                new GrowingCultures {Name = "Земляника лесная", GrowingType = growingtype13},
                new GrowingCultures {Name = "Земляника мускатная", GrowingType = growingtype13},
                new GrowingCultures {Name = "Клубника настоящая", GrowingType = growingtype13},
                new GrowingCultures {Name = "Клубника луговая", GrowingType = growingtype13},
                new GrowingCultures {Name = "Лещина крупная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Лещина обыкновенная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Малина", GrowingType = growingtype14},
                new GrowingCultures {Name = "Малина великолепная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Малина майсурская", GrowingType = growingtype14},
                new GrowingCultures {Name = "Малина пурпурноплодная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Малина розолистная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Наранхилла", GrowingType = growingtype14},
                new GrowingCultures {Name = "Облепиха крушиновидная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Пепино", GrowingType = growingtype14},
                new GrowingCultures {Name = "Слива карликовая", GrowingType = growingtype14},
                new GrowingCultures {Name = "Слива морская", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина американская", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина белая", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина золотистая", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина красная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина моховая", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина скальная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина чёрная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина широколистная", GrowingType = growingtype14},
                new GrowingCultures {Name = "Смородина Янчевского", GrowingType = growingtype14},
                new GrowingCultures {Name = "Тёрн", GrowingType = growingtype14},
                new GrowingCultures {Name = "Шиповник Вудса", GrowingType = growingtype14},
                new GrowingCultures {Name = "Шиповник иглистый", GrowingType = growingtype14},
                new GrowingCultures {Name = "Шиповник майский", GrowingType = growingtype14},
                new GrowingCultures {Name = "Шиповник морщинистый", GrowingType = growingtype14},
                new GrowingCultures {Name = "Топинамбур", GrowingType = growingtype15},
                new GrowingCultures {Name = "Батат", GrowingType = growingtype15},
                new GrowingCultures {Name = "Картофель", GrowingType = growingtype15},
                new GrowingCultures {Name = "Морковь", GrowingType = growingtype15},
                new GrowingCultures {Name = "Свёкла", GrowingType = growingtype15},
                new GrowingCultures {Name = "Репа", GrowingType = growingtype15},
                new GrowingCultures {Name = "Брюква", GrowingType = growingtype15},
                new GrowingCultures {Name = "Редька", GrowingType = growingtype15},
                new GrowingCultures {Name = "Редис", GrowingType = growingtype15},
                new GrowingCultures {Name = "Петрушка", GrowingType = growingtype15},
                new GrowingCultures {Name = "Пастернак", GrowingType = growingtype15},
                new GrowingCultures {Name = "Сельдерей", GrowingType = growingtype15},
                new GrowingCultures {Name = "Хрен", GrowingType = growingtype15},
            };
            foreach (var item in growingcultures) Context.GrowingCultureses.Add(item);
            Context.SaveChanges();
        }
    }

}