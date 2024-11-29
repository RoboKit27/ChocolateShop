/* Выводы табличек */

/* Получить всех пользователей с их ролями */
select 
U."Id",U."Name",R."Name" from "User" as U
join "Role" as R on R."Id"=U."RoleId"

/* Получить информацию про шоколадки */
select 
C."Name",C."Cost",C."ProductDate",C."BestBefore",C."Weight",
COM."Name" as "CompanyName",COM."Country" as "CompanyCountry",
T."Name" as "Type"
from "Chocolate" as C
join "Company" as COM on COM."Id"=C."CompanyId"
join "Type" as T on T."Id"=C."TypeId"

/* Получить информацию о заказах */
select
O."Id", C."Name" as "Client",
O."Date",
count(OC."OrderId") as "ProductCount",
sum(CH."Cost") as "Cost"
from "Order" as O
join "Client" as C on C."Id"=O."ClientId"
join "Order_Chocolate" as OC on OC."OrderId"=O."Id"
join "Chocolate" as CH on OC."ChocolateId"=CH."Id"
group by O."Id", C."Name"
