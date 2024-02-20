using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;
using System.Reflection.Metadata;
using XFood.Data.Models;

namespace XFood.Data
{
    public class XFoodContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Time> Time { get; set; }
        public DbSet<Pizzeria> Pizzerias { get; set; }
        public DbSet<CheckList> CheckLists { get; set; }
        public DbSet<Criterion> Criteria { get; set; }
        public DbSet<CriticalFactor> CriticalFactors { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<Schedule> Schedules { get; set; }
        public DbSet<OpportunitySchedule> OpportunitySchedules { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<ChecklistCriteria> ChecklistCriteria { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public XFoodContext(DbContextOptions<XFoodContext> options) : base(options) { }

        public XFoodContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Pizzeria>().HasData(
                new Pizzeria { Id = 1, Name = "Москва-13-2", Region = "Москва" },
                new Pizzeria { Id = 2, Name = "Москва-13-3", Region = "Москва" },
                new Pizzeria { Id = 3, Name = "Москва-13-4", Region = "Москва" },
                new Pizzeria { Id = 4, Name = "Калининград-1", Region = "Калининград" },
                new Pizzeria { Id = 5, Name = "Калининград-2", Region = "Калининград" },
                new Pizzeria { Id = 6, Name = "Калининград-3", Region = "Калининград" },
                new Pizzeria { Id = 7, Name = "Тучково-1", Region = "Беларусь" },
                new Pizzeria { Id = 8, Name = "Полоцк-1", Region = "Беларусь" },
                new Pizzeria { Id = 9, Name = "Орша-1", Region = "Беларусь" }
            );
            builder.Entity<Manager>().HasData(
                new Manager { Id = 1, FirstName = "Александр", LastName = "Иванов", Email = "alex@example.com", Telegram = "@alex_telegram", PizzeriaId = 1 },
                new Manager { Id = 2, FirstName = "Екатерина", LastName = "Смирнова", Email = "ekaterina@example.com", Telegram = "@ekaterina_telegram", PizzeriaId = 2 },
                new Manager { Id = 3, FirstName = "Дмитрий", LastName = "Петров", Email = "dmitry@example.com", Telegram = "@dmitry_telegram", PizzeriaId = 3 },
                new Manager { Id = 4, FirstName = "Мария", LastName = "Сидорова", Email = "maria@example.com", Telegram = "@maria_telegram", PizzeriaId = 4 },
                new Manager { Id = 5, FirstName = "Андрей", LastName = "Кузнецов", Email = "andrey@example.com", Telegram = "@andrey_telegram", PizzeriaId = 5 },
                new Manager { Id = 6, FirstName = "Ольга", LastName = "Семенова", Email = "olga@example.com", Telegram = "@olga_telegram", PizzeriaId = 6 },
                new Manager { Id = 7, FirstName = "Сергей", LastName = "Лебедев", Email = "sergey@example.com", Telegram = "@sergey_telegram", PizzeriaId = 7 },
                new Manager { Id = 8, FirstName = "Анастасия", LastName = "Новикова", Email = "anastasia@example.com", Telegram = "@anastasia_telegram", PizzeriaId = 8 },
                new Manager { Id = 9, FirstName = "Иван", LastName = "Морозов", Email = "ivan@example.com", Telegram = "@ivan_telegram", PizzeriaId = 9 },
                new Manager { Id = 10, FirstName = "Елена", LastName = "Васнецова", Email = "elena@example.com", Telegram = "@elena_telegram", PizzeriaId = 1 },
                new Manager { Id = 11, FirstName = "Павел", LastName = "Федоров", Email = "pavel@example.com", Telegram = "@pavel_telegram", PizzeriaId = 2 },
                new Manager { Id = 12, FirstName = "Алиса", LastName = "Соловьева", Email = "alisa@example.com", Telegram = "@alisa_telegram", PizzeriaId = 3 },
                new Manager { Id = 13, FirstName = "Никита", LastName = "Тихонов", Email = "nikita@example.com", Telegram = "@nikita_telegram", PizzeriaId = 4 },
                new Manager { Id = 14, FirstName = "Валерия", LastName = "Козлова", Email = "valeria@example.com", Telegram = "@valeria_telegram", PizzeriaId = 5 },
                new Manager { Id = 15, FirstName = "Григорий", LastName = "Игнатьев", Email = "grigory@example.com", Telegram = "@grigory_telegram", PizzeriaId = 6 },
                new Manager { Id = 16, FirstName = "Татьяна", LastName = "Смирнова", Email = "tatiana@example.com", Telegram = "@tatiana_telegram", PizzeriaId = 7 },
                new Manager { Id = 17, FirstName = "Артем", LastName = "Емельянов", Email = "artem@example.com", Telegram = "@artem_telegram", PizzeriaId = 8 },
                new Manager { Id = 18, FirstName = "Евгения", LastName = "Белова", Email = "evgenia@example.com", Telegram = "@evgenia_telegram", PizzeriaId = 9 },
                new Manager { Id = 19, FirstName = "Максим", LastName = "Третьяков", Email = "maxim@example.com", Telegram = "@maxim_telegram", PizzeriaId = 1 },
                new Manager { Id = 20, FirstName = "Виктория", LastName = "Жукова", Email = "viktoria@example.com", Telegram = "@viktoria_telegram", PizzeriaId = 2 }
            );
            builder.Entity<Criterion>().HasData(
                new Criterion { Id = 1, Name = "Форма всех сотрудников соответствует стандарту. \r\nСотрудники кухни (кассир при работе на упаковке) с бородой на всех станциях носят набородник", MaxPoints = 2, Section = "", PizzeriaId = 1 },
                new Criterion { Id = 2, Name = "Менеджер смены делает обходы.", MaxPoints = 2, Section = "", PizzeriaId = 1 },
                new Criterion { Id = 3, Name = "Сотрудники не используют личные телефоны в зеленой зоне пиццерии, не носят их в карманах.", MaxPoints = 2, Section = "", PizzeriaId = 1 },
                new Criterion { Id = 4, Name = "Продукт готовится по стандарту. Соблюдаются стандарты начинения и упаковки. Нет перерасхода ингредиентов. До 3-х ошибок, 4 и более - крит. фактор", MaxPoints = 4, Section = "Потери", PizzeriaId = 1 },
                new Criterion { Id = 5, Name = "При приемке товар взвешивается, пересчитывается. Товар на пол не ставится.  \r\nРазбор поставки не более 1,5 часов (ВЗ), не более 1 часа - тесто", MaxPoints = 2, Section = "Потери", PizzeriaId = 1 },
                new Criterion { Id = 6, Name = "Продукты не размораживаются в ГЦ и ХЦ, мойке, на печи. Не лежат на столах более чем 30 минут. Одновременная заготовка не более 1 ингредиента одним сотрудником.", MaxPoints = 4, Section = "Потери", PizzeriaId = 1 },
                new Criterion { Id = 7, Name = "На линии начинения на каждый сыпучий ингредиент есть отдельный стаканчик. Используются актуальные стаканчики.", MaxPoints = 1, Section = "Потери", PizzeriaId = 1 },
                new Criterion { Id = 8, Name = "У всех сумок есть место для хранения ,не хранятся на полу.", MaxPoints = 1, Section = "Курьеры", PizzeriaId = 1 },
                new Criterion { Id = 9, Name = "Внешний вид курьеров соответствует стандарту", MaxPoints = 1, Section = "Курьеры", PizzeriaId = 1 },
                new Criterion { Id = 10, Name = "Ответственный сотрудник не оставляет открытым денежный ящик.", MaxPoints = 1, Section = "Кассир", PizzeriaId = 1 },
                new Criterion { Id = 11, Name = "Кассир дружелюбен, моментально реагирует на гостя. \r\nПринимает заказы быстро, помогает с выбором. \r\nНе игнорирует гостя, не стоит спиной к нему, в закрытой позе. \r\nРеакция на звонок не более 30 секунд.", 
                    MaxPoints = 3, Section = "Касса", PizzeriaId = 1 },               
                new Criterion { Id = 12, Name = "Тесто хранится по стандарту.", MaxPoints = 2, Section = "Касса", PizzeriaId = 1 },
                new Criterion { Id = 13, Name = "Заказы в ресторан выданы на подносе согласно стандарту комплектации заказов. Гостю выдан чек (РБ). Пицца на металлическом подносе выдана согласно стандарту.", MaxPoints = 2, Section = "Тесто", PizzeriaId = 1 },
                new Criterion { Id = 14, Name = "Линия полностью заполнена гастроемкостями - герметична. \r\nПри отсутствии заказов линия и гастроемкости закрыты.", MaxPoints = 2, Section = "Кухня", PizzeriaId = 1 },
                new Criterion { Id = 15, Name = "Условия хранения продуктов и расходников соответствует стандартам \r\n(температура, 15 см от пола, пищевое/непищевое). \r\nВ желтой зоне нет вскрытых упаковок с напитками.", MaxPoints = 4, Section = "Кухня", PizzeriaId = 1 },
                new Criterion { Id = 16, Name = "Овощи моются по стандарту, необработанные овощи не кладут на столы в ГЦ и ХЦ.", MaxPoints = 3, Section = "Кухня", PizzeriaId = 1 },
                new Criterion { Id = 17, Name = "Пиццы готовятся согласно принципу конвейера. ", MaxPoints = 2, Section = "Кухня", PizzeriaId = 1 },
                new Criterion { Id = 18, Name = "Зал: чистый пол, нет следов от ботинок, сильных загрязнений.", MaxPoints = 2, Section = "Ресторан", PizzeriaId = 1 },
                new Criterion { Id = 19, Name = "Чистые столы. Подносы убираются в течение трех минут, нет остатков еды на убранных столах.", MaxPoints = 2, Section = "Ресторан", PizzeriaId = 1 },
                new Criterion { Id = 20, Name = "Руки моются и обрабатываются антисептиком в соответствии со стандартом мытья рук.", MaxPoints = 4, Section = "Сотрудник", PizzeriaId = 1 },
                new Criterion { Id = 21, Name = "Посуду моют согласно стандарту", MaxPoints = 3, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 22, Name = "Чистая линия начинения и стол раскатки, убирается вовремя и по стандарту.\r\n- если мусор собрали в руку - руки помыты.", MaxPoints = 2, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 23, Name = "Пицца-соус и альфредо закрывают крышкой при отстутствии заказов. \r\nПоловник меняют каждые два часа. - если хранится в соусе.", MaxPoints = 2, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 24, Name = "Сотрудники кухни используют перчатки по стандарту: уборка происходит только в перчатках. \r\nУборка без перчаток только без использования химии. ", MaxPoints = 2, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 25, Name = "Чисто в пищевой зоне (столы,полки, стены, пол, раковины, микроволновки, урна не переполнена)", MaxPoints = 1, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 26, Name = "Чисто в непищевой зоне (двери, колодец, стыки, стены, пол).", MaxPoints = 1, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 27, Name = "Менеджерской зона: чистота и порядок, отсутствуют напитки рядом с оборудованием.", MaxPoints = 1, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 28, Name = "Все проходы свободны , не захламлены , отсутствуют мусорные мешки, можно пройти без препятствий.", MaxPoints = 1, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 29, Name = "Химия и уборочный инвентарь хранится согласно стандарту. Уборочный инвентарь чистый.", MaxPoints = 1, Section = "Прочие", PizzeriaId = 1 },
                new Criterion { Id = 30, Name = "", MaxPoints = 2, Section = "Wow Фактор", PizzeriaId = 1 },
                new Criterion { Id = 31, Name = "Уберите балл, за то, что считаете особо важным, чему не уделяют на смене внимание.", MaxPoints = -4, Section = "Критический фактор", PizzeriaId = 1 },
                new Criterion { Id = 32, Name = "Критическое нарушение пищевой безопасности.", MaxPoints = -8, Section = "Критический фактор", PizzeriaId = 1 },
                new Criterion { Id = 33, Name = "Опоздание менеджера на смену позже открытия продаж.\r\n4 и более ошибок в начинении/ на упаковке.", MaxPoints = -8, Section = "Критический фактор", PizzeriaId = 1 }
            );

            builder.Entity<Criterion>().HasData(
                new Criterion { Id = 34, Name = "Форма всех сотрудников соответствует стандарту. \r\nСотрудники кухни (кассир при работе на упаковке) с бородой на всех станциях носят набородник", MaxPoints = 2, Section = "", PizzeriaId = 8 },
                new Criterion { Id = 35, Name = "Менеджер смены делает обходы.", MaxPoints = 2, Section = "", PizzeriaId = 8 },
                new Criterion { Id = 36, Name = "Сотрудники не используют личные телефоны в зеленой зоне пиццерии, не носят их в карманах.", MaxPoints = 2, Section = "", PizzeriaId = 8 },
                new Criterion { Id = 37, Name = "Продукт готовится по стандарту. Соблюдаются стандарты начинения и упаковки. Нет перерасхода ингредиентов. До 3-х ошибок, 4 и более - крит. фактор", MaxPoints = 4, Section = "Потери", PizzeriaId = 8 },
                new Criterion { Id = 38, Name = "При приемке товар взвешивается, пересчитывается. Товар на пол не ставится.  \r\nРазбор поставки не более 1,5 часов (ВЗ), не более 1 часа - тесто", MaxPoints = 2, Section = "Потери", PizzeriaId = 8 },
                new Criterion { Id = 39, Name = "Продукты не размораживаются в ГЦ и ХЦ, мойке, на печи. Не лежат на столах более чем 30 минут. Одновременная заготовка не более 1 ингредиента одним сотрудником.", MaxPoints = 4, Section = "Потери", PizzeriaId = 8 },
                new Criterion { Id = 40, Name = "На линии начинения на каждый сыпучий ингредиент есть отдельный стаканчик. Используются актуальные стаканчики.", MaxPoints = 1, Section = "Потери", PizzeriaId = 8 },
                new Criterion { Id = 41, Name = "У всех сумок есть место для хранения ,не хранятся на полу.", MaxPoints = 1, Section = "Курьеры", PizzeriaId = 8 },
                new Criterion { Id = 42, Name = "Внешний вид курьеров соответствует стандарту", MaxPoints = 1, Section = "Курьеры", PizzeriaId = 8 },
                new Criterion { Id = 43, Name = "Ответственный сотрудник не оставляет открытым денежный ящик.", MaxPoints = 1, Section = "Кассир", PizzeriaId = 8 },
                new Criterion { Id = 44, Name = "Кассир дружелюбен, моментально реагирует на гостя. \r\nПринимает заказы быстро, помогает с выбором. \r\nНе игнорирует гостя, не стоит спиной к нему, в закрытой позе. \r\nРеакция на звонок не более 30 секунд.", MaxPoints = 3, Section = "Касса", PizzeriaId = 8},
                new Criterion { Id = 45, Name = "Тесто хранится по стандарту.", MaxPoints = 2, Section = "Касса", PizzeriaId = 8 },
                new Criterion { Id = 46, Name = "Заказы в ресторан выданы на подносе согласно стандарту комплектации заказов. Гостю выдан чек (РБ). Пицца на металлическом подносе выдана согласно стандарту.", MaxPoints = 2, Section = "Тесто", PizzeriaId = 8 },
                new Criterion { Id = 47, Name = "Линия полностью заполнена гастроемкостями - герметична. \r\nПри отсутствии заказов линия и гастроемкости закрыты.", MaxPoints = 2, Section = "Кухня", PizzeriaId = 8 },
                new Criterion { Id = 48, Name = "Условия хранения продуктов и расходников соответствует стандартам \r\n(температура, 15 см от пола, пищевое/непищевое). \r\nВ желтой зоне нет вскрытых упаковок с напитками.", MaxPoints = 4, Section = "Кухня", PizzeriaId = 8 },
                new Criterion { Id = 49, Name = "Овощи моются по стандарту, необработанные овощи не кладут на столы в ГЦ и ХЦ.", MaxPoints = 3, Section = "Кухня", PizzeriaId = 8 },
                new Criterion { Id = 50, Name = "Пиццы готовятся согласно принципу конвейера. ", MaxPoints = 2, Section = "Кухня", PizzeriaId = 8 },
                new Criterion { Id = 51, Name = "Зал: чистый пол, нет следов от ботинок, сильных загрязнений.", MaxPoints = 2, Section = "Ресторан", PizzeriaId = 8 },
                new Criterion { Id = 52, Name = "Чистые столы. Подносы убираются в течение трех минут, нет остатков еды на убранных столах.", MaxPoints = 2, Section = "Ресторан", PizzeriaId = 8 },
                new Criterion { Id = 53, Name = "Руки моются и обрабатываются антисептиком в соответствии со стандартом мытья рук.", MaxPoints = 4, Section = "Сотрудник", PizzeriaId = 8 },
                new Criterion { Id = 54, Name = "Посуду моют согласно стандарту", MaxPoints = 3, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 55, Name = "Чистая линия начинения и стол раскатки, убирается вовремя и по стандарту.\r\n- если мусор собрали в руку - руки помыты.", MaxPoints = 2, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 56, Name = "Пицца-соус и альфредо закрывают крышкой при отстутствии заказов. \r\nПоловник меняют каждые два часа. - если хранится в соусе.", MaxPoints = 2, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 57, Name = "Сотрудники кухни используют перчатки по стандарту: уборка происходит только в перчатках. \r\nУборка без перчаток только без использования химии. ", MaxPoints = 2, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 58, Name = "Чисто в пищевой зоне (столы,полки, стены, пол, раковины, микроволновки, урна не переполнена)", MaxPoints = 1, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 59, Name = "Чисто в непищевой зоне (двери, колодец, стыки, стены, пол).", MaxPoints = 1, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 60, Name = "Менеджерской зона: чистота и порядок, отсутствуют напитки рядом с оборудованием.", MaxPoints = 1, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 61, Name = "Все проходы свободны , не захламлены , отсутствуют мусорные мешки, можно пройти без препятствий.", MaxPoints = 1, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 62, Name = "Химия и уборочный инвентарь хранится согласно стандарту. Уборочный инвентарь чистый.", MaxPoints = 1, Section = "Прочие", PizzeriaId = 8 },
                new Criterion { Id = 63, Name = "", MaxPoints = 2, Section = "Wow Фактор", PizzeriaId = 1 },
                new Criterion { Id = 64, Name = "Уберите балл, за то, что считаете особо важным, чему не уделяют на смене внимание.", MaxPoints = -4, Section = "Критический фактор", PizzeriaId = 8 },
                new Criterion { Id = 65, Name = "Критическое нарушение пищевой безопасности.", MaxPoints = -8, Section = "Критический фактор", PizzeriaId = 8 },
                new Criterion { Id = 66, Name = "Опоздание менеджера на смену позже открытия продаж.\r\n4 и более ошибок в начинении/ на упаковке.", MaxPoints = -8, Section = "Критический фактор", PizzeriaId = 8 }
            );

            base.OnModelCreating(builder);
        }
    }
    
}
