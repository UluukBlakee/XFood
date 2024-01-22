using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class DataSeedPolotsk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[,]
                {
                    { 34, 2, "Форма всех сотрудников соответствует стандарту. \r\nСотрудники кухни (кассир при работе на упаковке) с бородой на всех станциях носят набородник", 8, "" },
                    { 35, 2, "Менеджер смены делает обходы.", 8, "" },
                    { 36, 2, "Сотрудники не используют личные телефоны в зеленой зоне пиццерии, не носят их в карманах.", 8, "" },
                    { 37, 4, "Продукт готовится по стандарту. Соблюдаются стандарты начинения и упаковки. Нет перерасхода ингредиентов. До 3-х ошибок, 4 и более - крит. фактор", 8, "Потери" },
                    { 38, 2, "При приемке товар взвешивается, пересчитывается. Товар на пол не ставится.  \r\nРазбор поставки не более 1,5 часов (ВЗ), не более 1 часа - тесто", 8, "Потери" },
                    { 39, 4, "Продукты не размораживаются в ГЦ и ХЦ, мойке, на печи. Не лежат на столах более чем 30 минут. Одновременная заготовка не более 1 ингредиента одним сотрудником.", 8, "Потери" },
                    { 40, 1, "На линии начинения на каждый сыпучий ингредиент есть отдельный стаканчик. Используются актуальные стаканчики.", 8, "Потери" },
                    { 41, 1, "У всех сумок есть место для хранения ,не хранятся на полу.", 8, "Курьеры" },
                    { 42, 1, "Внешний вид курьеров соответствует стандарту", 8, "Курьеры" },
                    { 43, 1, "Ответственный сотрудник не оставляет открытым денежный ящик.", 8, "Кассир" },
                    { 44, 3, "Кассир дружелюбен, моментально реагирует на гостя. \r\nПринимает заказы быстро, помогает с выбором. \r\nНе игнорирует гостя, не стоит спиной к нему, в закрытой позе. \r\nРеакция на звонок не более 30 секунд.", 8, "Касса" },
                    { 45, 2, "Тесто хранится по стандарту.", 8, "Касса" },
                    { 46, 2, "Заказы в ресторан выданы на подносе согласно стандарту комплектации заказов. Гостю выдан чек (РБ). Пицца на металлическом подносе выдана согласно стандарту.", 8, "Тесто" },
                    { 47, 2, "Линия полностью заполнена гастроемкостями - герметична. \r\nПри отсутствии заказов линия и гастроемкости закрыты.", 8, "Кухня" },
                    { 48, 4, "Условия хранения продуктов и расходников соответствует стандартам \r\n(температура, 15 см от пола, пищевое/непищевое). \r\nВ желтой зоне нет вскрытых упаковок с напитками.", 8, "Кухня" },
                    { 49, 3, "Овощи моются по стандарту, необработанные овощи не кладут на столы в ГЦ и ХЦ.", 8, "Кухня" },
                    { 50, 2, "Пиццы готовятся согласно принципу конвейера. ", 8, "Кухня" },
                    { 51, 2, "Зал: чистый пол, нет следов от ботинок, сильных загрязнений.", 8, "Ресторан" },
                    { 52, 2, "Чистые столы. Подносы убираются в течение трех минут, нет остатков еды на убранных столах.", 8, "Ресторан" },
                    { 53, 4, "Руки моются и обрабатываются антисептиком в соответствии со стандартом мытья рук.", 8, "Сотрудник" },
                    { 54, 3, "Посуду моют согласно стандарту", 8, "Прочие" },
                    { 55, 2, "Чистая линия начинения и стол раскатки, убирается вовремя и по стандарту.\r\n- если мусор собрали в руку - руки помыты.", 8, "Прочие" },
                    { 56, 2, "Пицца-соус и альфредо закрывают крышкой при отстутствии заказов. \r\nПоловник меняют каждые два часа. - если хранится в соусе.", 8, "Прочие" },
                    { 57, 2, "Сотрудники кухни используют перчатки по стандарту: уборка происходит только в перчатках. \r\nУборка без перчаток только без использования химии. ", 8, "Прочие" },
                    { 58, 1, "Чисто в пищевой зоне (столы,полки, стены, пол, раковины, микроволновки, урна не переполнена)", 8, "Прочие" },
                    { 59, 1, "Чисто в непищевой зоне (двери, колодец, стыки, стены, пол).", 8, "Прочие" },
                    { 60, 1, "Менеджерской зона: чистота и порядок, отсутствуют напитки рядом с оборудованием.", 8, "Прочие" },
                    { 61, 1, "Все проходы свободны , не захламлены , отсутствуют мусорные мешки, можно пройти без препятствий.", 8, "Прочие" },
                    { 62, 1, "Химия и уборочный инвентарь хранится согласно стандарту. Уборочный инвентарь чистый.", 8, "Прочие" },
                    { 63, 2, "", 1, "Wow Фактор" },
                    { 64, -4, "Уберите балл, за то, что считаете особо важным, чему не уделяют на смене внимание.", 8, "Критический фактор" },
                    { 65, -8, "Критическое нарушение пищевой безопасности.", 8, "Критический фактор" },
                    { 66, -8, "Опоздание менеджера на смену позже открытия продаж.\r\n4 и более ошибок в начинении/ на упаковке.", 8, "Критический фактор" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 34);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 35);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 36);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 37);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 38);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 39);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 40);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 41);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 42);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 43);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 44);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 45);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 46);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 47);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 48);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 49);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 50);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 51);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 52);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 53);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 54);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 55);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 56);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 57);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 58);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 59);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 60);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 61);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 62);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 63);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 64);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 66);
        }
    }
}
