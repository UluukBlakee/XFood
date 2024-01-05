using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class DataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pizzerias",
                columns: new[] { "Id", "Name", "Region" },
                values: new object[,]
                {
                    { 1, "Москва-13-2", "Москва" },
                    { 2, "Москва-13-3", "Москва" },
                    { 3, "Москва-13-4", "Москва" },
                    { 4, "Калининград-1", "Калининград" },
                    { 5, "Калининград-2", "Калининград" },
                    { 6, "Калининград-3", "Калининград" },
                    { 7, "Тучково-1", "Беларусь" },
                    { 8, "Полоцк-1", "Беларусь" },
                    { 9, "Орша-1", "Беларусь" }
                });

            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "CheckListId", "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[,]
                {
                    { 1, null, 2, "Форма всех сотрудников соответствует стандарту. \r\nСотрудники кухни (кассир при работе на упаковке) с бородой на всех станциях носят набородник", 1, "" },
                    { 2, null, 2, "Менеджер смены делает обходы.", 1, "" },
                    { 3, null, 2, "Сотрудники не используют личные телефоны в зеленой зоне пиццерии, не носят их в карманах.", 1, "" },
                    { 4, null, 4, "Продукт готовится по стандарту. Соблюдаются стандарты начинения и упаковки. Нет перерасхода ингредиентов. До 3-х ошибок, 4 и более - крит. фактор", 1, "Потери" },
                    { 5, null, 2, "При приемке товар взвешивается, пересчитывается. Товар на пол не ставится.  \r\nРазбор поставки не более 1,5 часов (ВЗ), не более 1 часа - тесто", 1, "Потери" },
                    { 6, null, 4, "Продукты не размораживаются в ГЦ и ХЦ, мойке, на печи. Не лежат на столах более чем 30 минут. Одновременная заготовка не более 1 ингредиента одним сотрудником.", 1, "Потери" },
                    { 7, null, 1, "На линии начинения на каждый сыпучий ингредиент есть отдельный стаканчик. Используются актуальные стаканчики.", 1, "Потери" },
                    { 8, null, 1, "У всех сумок есть место для хранения ,не хранятся на полу.", 1, "Курьеры" },
                    { 9, null, 1, "Внешний вид курьеров соответствует стандарту", 1, "Курьеры" },
                    { 10, null, 1, "Ответственный сотрудник не оставляет открытым денежный ящик.", 1, "Кассир" },
                    { 11, null, 3, "Кассир дружелюбен, моментально реагирует на гостя. \r\nПринимает заказы быстро, помогает с выбором. \r\nНе игнорирует гостя, не стоит спиной к нему, в закрытой позе. \r\nРеакция на звонок не более 30 секунд.", 1, "Касса" },
                    { 12, null, 2, "Тесто хранится по стандарту.", 1, "Касса" },
                    { 13, null, 2, "Заказы в ресторан выданы на подносе согласно стандарту комплектации заказов. Гостю выдан чек (РБ). Пицца на металлическом подносе выдана согласно стандарту.", 1, "Тесто" },
                    { 14, null, 2, "Линия полностью заполнена гастроемкостями - герметична. \r\nПри отсутствии заказов линия и гастроемкости закрыты.", 1, "Кухня" },
                    { 15, null, 4, "Условия хранения продуктов и расходников соответствует стандартам \r\n(температура, 15 см от пола, пищевое/непищевое). \r\nВ желтой зоне нет вскрытых упаковок с напитками.", 1, "Кухня" },
                    { 16, null, 3, "Овощи моются по стандарту, необработанные овощи не кладут на столы в ГЦ и ХЦ.", 1, "Кухня" },
                    { 17, null, 2, "Пиццы готовятся согласно принципу конвейера. ", 1, "Кухня" },
                    { 18, null, 2, "Зал: чистый пол, нет следов от ботинок, сильных загрязнений.", 1, "Ресторан" },
                    { 19, null, 2, "Чистые столы. Подносы убираются в течение трех минут, нет остатков еды на убранных столах.", 1, "Ресторан" },
                    { 20, null, 4, "Руки моются и обрабатываются антисептиком в соответствии со стандартом мытья рук.", 1, "Сотрудник" },
                    { 21, null, 3, "Посуду моют согласно стандарту", 1, "Прочие" },
                    { 22, null, 2, "Чистая линия начинения и стол раскатки, убирается вовремя и по стандарту.\r\n- если мусор собрали в руку - руки помыты.", 1, "Прочие" },
                    { 23, null, 2, "Пицца-соус и альфредо закрывают крышкой при отстутствии заказов. \r\nПоловник меняют каждые два часа. - если хранится в соусе.", 1, "Прочие" },
                    { 24, null, 2, "Сотрудники кухни используют перчатки по стандарту: уборка происходит только в перчатках. \r\nУборка без перчаток только без использования химии. ", 1, "Прочие" },
                    { 25, null, 1, "Чисто в пищевой зоне (столы,полки, стены, пол, раковины, микроволновки, урна не переполнена)", 1, "Прочие" },
                    { 26, null, 1, "Чисто в непищевой зоне (двери, колодец, стыки, стены, пол).", 1, "Прочие" },
                    { 27, null, 1, "Менеджерской зона: чистота и порядок, отсутствуют напитки рядом с оборудованием.", 1, "Прочие" },
                    { 28, null, 1, "Все проходы свободны , не захламлены , отсутствуют мусорные мешки, можно пройти без препятствий.", 1, "Прочие" },
                    { 29, null, 1, "Химия и уборочный инвентарь хранится согласно стандарту. Уборочный инвентарь чистый.", 1, "Прочие" },
                    { 30, null, 2, "", 1, "Wow Фактор" },
                    { 31, null, -4, "Уберите балл, за то, что считаете особо важным, чему не уделяют на смене внимание.", 1, "Критический фактор" },
                    { 32, null, -8, "Критическое нарушение пищевой безопасности.", 1, "Критический фактор" },
                    { 33, null, -8, "Опоздание менеджера на смену позже открытия продаж.\r\n4 и более ошибок в начинении/ на упаковке.", 1, "Критический фактор" }
                });

            migrationBuilder.InsertData(
                table: "Managers",
                columns: new[] { "Id", "FirstName", "LastName", "PizzeriaId" },
                values: new object[,]
                {
                    { 1, "Александр", "Иванов", 1 },
                    { 2, "Екатерина", "Смирнова", 2 },
                    { 3, "Дмитрий", "Петров", 3 },
                    { 4, "Мария", "Сидорова", 4 },
                    { 5, "Андрей", "Кузнецов", 5 },
                    { 6, "Ольга", "Семенова", 6 },
                    { 7, "Сергей", "Лебедев", 7 },
                    { 8, "Анастасия", "Новикова", 8 },
                    { 9, "Иван", "Морозов", 9 },
                    { 10, "Елена", "Васнецова", 1 },
                    { 11, "Павел", "Федоров", 2 },
                    { 12, "Алиса", "Соловьева", 3 },
                    { 13, "Никита", "Тихонов", 4 },
                    { 14, "Валерия", "Козлова", 5 },
                    { 15, "Григорий", "Игнатьев", 6 },
                    { 16, "Татьяна", "Смирнова", 7 },
                    { 17, "Артем", "Емельянов", 8 },
                    { 18, "Евгения", "Белова", 9 },
                    { 19, "Максим", "Третьяков", 1 },
                    { 20, "Виктория", "Жукова", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 27);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 28);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 29);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 30);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 31);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 32);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 33);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pizzerias",
                keyColumn: "Id",
                keyValue: 9);
        }
    }
}
