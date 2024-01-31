using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace XFood.Data.Migrations
{
    public partial class UpdateDataSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 65);

            migrationBuilder.DeleteData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 66);

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Критическое нарушение пищевой безопасности. \r\nОпоздание менеджера на смену позже открытия продаж.\r\n4 и более ошибок в начинении/ на упаковке.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[] { 2, "Форма всех сотрудников соответствует стандарту. \r\nСотрудники кухни (кассир при работе на упаковке) с бородой на всех станциях носят набородник", 8, "" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Менеджер смены делает обходы.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Сотрудники не используют личные телефоны в зеленой зоне пиццерии, не носят их в карманах.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "MaxPoints", "Name", "Section" },
                values: new object[] { 4, "Продукт готовится по стандарту. Соблюдаются стандарты начинения и упаковки. Нет перерасхода ингредиентов. До 3-х ошибок, 4 и более - крит. фактор", "Потери" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 2, "При приемке товар взвешивается, пересчитывается. Товар на пол не ставится.  \r\nРазбор поставки не более 1,5 часов (ВЗ), не более 1 часа - тесто" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 4, "Продукты не размораживаются в ГЦ и ХЦ, мойке, на печи. Не лежат на столах более чем 30 минут. Одновременная заготовка не более 1 ингредиента одним сотрудником." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 1, "На линии начинения на каждый сыпучий ингредиент есть отдельный стаканчик. Используются актуальные стаканчики." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Name", "Section" },
                values: new object[] { "У всех сумок есть место для хранения ,не хранятся на полу.", "Курьеры" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "Внешний вид курьеров соответствует стандарту");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Name", "Section" },
                values: new object[] { "Ответственный сотрудник не оставляет открытым денежный ящик.", "Кассир" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "MaxPoints", "Name", "Section" },
                values: new object[] { 3, "Кассир дружелюбен, моментально реагирует на гостя. \r\nПринимает заказы быстро, помогает с выбором. \r\nНе игнорирует гостя, не стоит спиной к нему, в закрытой позе. \r\nРеакция на звонок не более 30 секунд.", "Касса" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 2, "Тесто хранится по стандарту." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Name", "Section" },
                values: new object[] { "Заказы в ресторан выданы на подносе согласно стандарту комплектации заказов. Гостю выдан чек (РБ). Пицца на металлическом подносе выдана согласно стандарту.", "Тесто" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Name", "Section" },
                values: new object[] { "Линия полностью заполнена гастроемкостями - герметична. \r\nПри отсутствии заказов линия и гастроемкости закрыты.", "Кухня" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 4, "Условия хранения продуктов и расходников соответствует стандартам \r\n(температура, 15 см от пола, пищевое/непищевое). \r\nВ желтой зоне нет вскрытых упаковок с напитками." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 3, "Овощи моются по стандарту, необработанные овощи не кладут на столы в ГЦ и ХЦ." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 2, "Пиццы готовятся согласно принципу конвейера. " });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Name", "Section" },
                values: new object[] { "Зал: чистый пол, нет следов от ботинок, сильных загрязнений.", "Ресторан" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Чистые столы. Подносы убираются в течение трех минут, нет остатков еды на убранных столах.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "MaxPoints", "Name", "Section" },
                values: new object[] { 4, "Руки моются и обрабатываются антисептиком в соответствии со стандартом мытья рук.", "Сотрудник" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "MaxPoints", "Name", "Section" },
                values: new object[] { 3, "Посуду моют согласно стандарту", "Прочие" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 2, "Чистая линия начинения и стол раскатки, убирается вовремя и по стандарту.\r\n- если мусор собрали в руку - руки помыты." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Пицца-соус и альфредо закрывают крышкой при отстутствии заказов. \r\nПоловник меняют каждые два часа. - если хранится в соусе.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Сотрудники кухни используют перчатки по стандарту: уборка происходит только в перчатках. \r\nУборка без перчаток только без использования химии. ");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 1, "Чисто в пищевой зоне (столы,полки, стены, пол, раковины, микроволновки, урна не переполнена)" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Чисто в непищевой зоне (двери, колодец, стыки, стены, пол).");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Менеджерской зона: чистота и порядок, отсутствуют напитки рядом с оборудованием.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Все проходы свободны , не захламлены , отсутствуют мусорные мешки, можно пройти без препятствий.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "Химия и уборочный инвентарь хранится согласно стандарту. Уборочный инвентарь чистый.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[] { 2, "", 1, "Wow Фактор" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[] { -4, "Уберите балл, за то, что считаете особо важным, чему не уделяют на смене внимание.", 8, "Критический фактор" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { -8, "Критическое нарушение пищевой безопасности. \r\nОпоздание менеджера на смену позже открытия продаж.\r\n4 и более ошибок в начинении/ на упаковке." });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 32,
                column: "Name",
                value: "Критическое нарушение пищевой безопасности.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 33,
                columns: new[] { "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[] { -8, "Опоздание менеджера на смену позже открытия продаж.\r\n4 и более ошибок в начинении/ на упаковке.", 1, "Критический фактор" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 34,
                column: "Name",
                value: "Форма всех сотрудников соответствует стандарту. \r\nСотрудники кухни (кассир при работе на упаковке) с бородой на всех станциях носят набородник");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 35,
                column: "Name",
                value: "Менеджер смены делает обходы.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 36,
                columns: new[] { "MaxPoints", "Name", "Section" },
                values: new object[] { 2, "Сотрудники не используют личные телефоны в зеленой зоне пиццерии, не носят их в карманах.", "" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 37,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 4, "Продукт готовится по стандарту. Соблюдаются стандарты начинения и упаковки. Нет перерасхода ингредиентов. До 3-х ошибок, 4 и более - крит. фактор" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 38,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 2, "При приемке товар взвешивается, пересчитывается. Товар на пол не ставится.  \r\nРазбор поставки не более 1,5 часов (ВЗ), не более 1 часа - тесто" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 39,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 4, "Продукты не размораживаются в ГЦ и ХЦ, мойке, на печи. Не лежат на столах более чем 30 минут. Одновременная заготовка не более 1 ингредиента одним сотрудником." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 40,
                columns: new[] { "Name", "Section" },
                values: new object[] { "На линии начинения на каждый сыпучий ингредиент есть отдельный стаканчик. Используются актуальные стаканчики.", "Потери" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 41,
                column: "Name",
                value: "У всех сумок есть место для хранения ,не хранятся на полу.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 42,
                columns: new[] { "Name", "Section" },
                values: new object[] { "Внешний вид курьеров соответствует стандарту", "Курьеры" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 43,
                columns: new[] { "MaxPoints", "Name", "Section" },
                values: new object[] { 1, "Ответственный сотрудник не оставляет открытым денежный ящик.", "Кассир" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 44,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 3, "Кассир дружелюбен, моментально реагирует на гостя. \r\nПринимает заказы быстро, помогает с выбором. \r\nНе игнорирует гостя, не стоит спиной к нему, в закрытой позе. \r\nРеакция на звонок не более 30 секунд." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 45,
                columns: new[] { "Name", "Section" },
                values: new object[] { "Тесто хранится по стандарту.", "Касса" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 46,
                columns: new[] { "Name", "Section" },
                values: new object[] { "Заказы в ресторан выданы на подносе согласно стандарту комплектации заказов. Гостю выдан чек (РБ). Пицца на металлическом подносе выдана согласно стандарту.", "Тесто" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 47,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 2, "Линия полностью заполнена гастроемкостями - герметична. \r\nПри отсутствии заказов линия и гастроемкости закрыты." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 48,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 4, "Условия хранения продуктов и расходников соответствует стандартам \r\n(температура, 15 см от пола, пищевое/непищевое). \r\nВ желтой зоне нет вскрытых упаковок с напитками." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 49,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 3, "Овощи моются по стандарту, необработанные овощи не кладут на столы в ГЦ и ХЦ." });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 50,
                columns: new[] { "Name", "Section" },
                values: new object[] { "Пиццы готовятся согласно принципу конвейера. ", "Кухня" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 51,
                column: "Name",
                value: "Зал: чистый пол, нет следов от ботинок, сильных загрязнений.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 52,
                columns: new[] { "MaxPoints", "Name", "Section" },
                values: new object[] { 2, "Чистые столы. Подносы убираются в течение трех минут, нет остатков еды на убранных столах.", "Ресторан" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 53,
                columns: new[] { "MaxPoints", "Name", "Section" },
                values: new object[] { 4, "Руки моются и обрабатываются антисептиком в соответствии со стандартом мытья рук.", "Сотрудник" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 54,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 3, "Посуду моют согласно стандарту" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 55,
                column: "Name",
                value: "Чистая линия начинения и стол раскатки, убирается вовремя и по стандарту.\r\n- если мусор собрали в руку - руки помыты.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 56,
                column: "Name",
                value: "Пицца-соус и альфредо закрывают крышкой при отстутствии заказов. \r\nПоловник меняют каждые два часа. - если хранится в соусе.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 57,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { 2, "Сотрудники кухни используют перчатки по стандарту: уборка происходит только в перчатках. \r\nУборка без перчаток только без использования химии. " });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 58,
                column: "Name",
                value: "Чисто в пищевой зоне (столы,полки, стены, пол, раковины, микроволновки, урна не переполнена)");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 59,
                column: "Name",
                value: "Чисто в непищевой зоне (двери, колодец, стыки, стены, пол).");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 60,
                column: "Name",
                value: "Менеджерской зона: чистота и порядок, отсутствуют напитки рядом с оборудованием.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 61,
                column: "Name",
                value: "Все проходы свободны , не захламлены , отсутствуют мусорные мешки, можно пройти без препятствий.");

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 62,
                columns: new[] { "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[] { 1, "Химия и уборочный инвентарь хранится согласно стандарту. Уборочный инвентарь чистый.", 8, "Прочие" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 63,
                columns: new[] { "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[] { 2, "", 1, "Wow Фактор" });

            migrationBuilder.UpdateData(
                table: "Criteria",
                keyColumn: "Id",
                keyValue: 64,
                columns: new[] { "MaxPoints", "Name" },
                values: new object[] { -4, "Уберите балл, за то, что считаете особо важным, чему не уделяют на смене внимание." });

            migrationBuilder.InsertData(
                table: "Criteria",
                columns: new[] { "Id", "MaxPoints", "Name", "PizzeriaId", "Section" },
                values: new object[,]
                {
                    { 65, -8, "Критическое нарушение пищевой безопасности.", 8, "Критический фактор" },
                    { 66, -8, "Опоздание менеджера на смену позже открытия продаж.\r\n4 и более ошибок в начинении/ на упаковке.", 8, "Критический фактор" }
                });
        }
    }
}
