# Приложение с микросервисной архитектурой
Приложение состоит из трех сервисов:<br/>
1.Сервис аутентификации и авторизации.<br/>
2.Сервис с бизнес-логикой.<br/>
3.Сервис с web клиентом на Angular.


## Сборка и запуск всего приложения (трех сервисов)

1. Необходимо в проекте
[WorkTime.AuthSerice.Data](https://github.com/SergeiZahar86/PJ1.WorkTime.AuthService.WebApi) 
добавить одну из библиотек
[microsoft.entityframeworkcore.sqlserver](https://www.nuget.org/packages/Microsoft.EntityFrameworkCore.SqlServer/)
или
[npgsql.entityframeworkcore.postgresql](https://www.nuget.org/packages/Npgsql.EntityFrameworkCore.PostgreSQL/)
в зависимости от используемой базы данных

2. Поменять строку подключения к базе данных в проекте
[WorkTime.AuthService.WebApi](https://github.com/SergeiZahar86/PJ1.WorkTime.AuthService.WebApi)

3. Запустить команду по созданию миграций из проекта
[WorkTime.AuthService.WebApi](https://github.com/SergeiZahar86/PJ1.WorkTime.AuthService.WebApi).
Сделать это можно либо из командной строки,
либо через графический интерфейс плагина
[Entity Framework Core UI](https://plugins.jetbrains.com/plugin/18147-entity-framework-core-ui)

4. После автосоздания миграций, в проекте
[WorkTime.AuthService.WebApi](https://github.com/SergeiZahar86/PJ1.WorkTime.AuthService.WebApi).
необходимо выполнить 
команду Update Database либо через командную
строку, либо через графический интерфейс плагина
[Entity Framework Core UI](https://plugins.jetbrains.com/plugin/18147-entity-framework-core-ui)
при этом на сервере базы данных будет создана
рабочая база данных.

5. Для базы PostgreSQL необходимо изменить работу 
с датой и временем путем добавления
строки (уже добавнено)
```c#
AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
```
в класс Program и Startup.

6. Запустить проект 
[WorkTime.AuthService.WebApi](https://github.com/SergeiZahar86/PJ1.WorkTime.AuthService.WebApi)
в дебаге.

7. Во время запуска произойдет заполнение 
базы данных начальными данными из файла Program.












