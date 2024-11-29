/* Тестовые данные */

insert into "Role"("Name")
values ('Administator'), ('Manager');

insert into "Client"("Name","Phone","Gmail")
values ('Fedor','+79562431234',null), 
('Ivan','+82539487261','ivan.sinicin@ya.ru'),
(null,'+10273561265','bigboss@gmail.com');

insert into "User"("Name","RoleId")
values ('Abraham',1),('Tony',2),
('Egor',2);

insert into "Company"("Name","Country")
values ('Alpen Gold','USA'),('Milka','Russia'),
('Kinder','Italy');

insert into "Type"("Name")
values ('Dark'),('White'),
('Milk');

insert into "Additive"("Name")
values ('Nuts'),('Strawberry'),('Banana'),
('Coconut'),('Mango'),('Air');

insert into "Chocolate"("Name","Cost","ProductDate","BestBefore","Weight","CompanyId","TypeId")
values ('Strawberry',220,'25.06.24',3,80,1,3),
('Forest',350,'25.06.24',3,80,2,1),
('Air Coconut',268,'25.06.24',3,80,2,3),
('Mango Summer',500,'25.06.24',3,80,3,2);

insert into "Chocolate_Additive"("ChocolateId","AdditiveId")
values (1,2),(2,1),(2,2),(3,4),(3,6),(4,5),(4,2),(4,3);

insert into "Order"("Date","ClientId")
values ('02.07.24',1),
('02.07.24',1),
('03.07.24',1),
('05.07.24',3),
('01.07.24',2),
('12.07.24',3);

insert into "Order_Chocolate"("OrderId","ChocolateId")
values (1,1),(1,1),(2,3),(3,1),(4,4),(4,2),(5,2),
(5,4),(6,1),(6,1);
