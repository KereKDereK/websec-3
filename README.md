# !Актуальная версия приложения находится в ветке main!
Для начала работы с приложением необходимы:
# 1.	База Данных
-	Скачать и установть MySQL workbench + server
-	Скачать dump базы данных, расположенный по пути: Server/ StoGramm.sql
-	## Создать пользователя с username – student и паролем – P@ssw0rd и правами администратора.
    1) Зайти в пункт Server -> Users and Privileges
    ![image](https://user-images.githubusercontent.com/75019623/209462580-09a93377-a9f0-451e-9d94-b98efe731bc3.png)
    2) Нажать на Add Acount
    ![image](https://user-images.githubusercontent.com/75019623/209462600-6515a661-c0c3-4232-a406-6e498bdcf5fc.png)
    3) Ввести имя пользователя и пароль
    4) Перейти во вкладку Administrative Roles и выставить флаг DBA
    ![image](https://user-images.githubusercontent.com/75019623/209462653-176a97c2-9623-42aa-bd40-53032c631644.png)

    5) Нажать кнопку Apply
    
 1.	В MySQL Workbench выбрать пункт Database -> Connect to database
    ![image](https://user-images.githubusercontent.com/75019623/209459340-0f38de15-ccc4-4646-b46b-6337668f9bbd.png)

 2.	После подключения выбрать пункт Server -> Data Import
    ![image](https://user-images.githubusercontent.com/75019623/209459363-7cd6aaa9-b61d-4045-9a33-86fcc5ccc0df.png)

 3.	Выбрать Import from Self-Contained File
    ![image](https://user-images.githubusercontent.com/75019623/209459373-abe3d39b-eb37-4d70-9c46-09ba4a03d1df.png)

 4.	Нажать на Start Import и открыть полученную схему
    
# 2.	Server
-	Скачать и установить Visual Studio
-	При создании проекта выбрать клонирование из репозитория
-	Вставить URL из репозитория
![image](https://user-images.githubusercontent.com/75019623/209459450-0d4d78a5-3c35-4d5b-95df-4b40b3bd1090.png)

-	Склонировать проект на компьютер
-	В обозревателе решений открыть файл проекта Server.sln
-	Запустить пункт Server
![image](https://user-images.githubusercontent.com/75019623/209459462-5add70c6-b822-4ef3-b1f6-1f16f8e4b5c7.png)

# 3.	Web
-	Скачать и установить Visual Studio Code
-	Открыть папку с проектом websec-3
-	В открытом проекте нажать Ctrl+Shift+`, откроется терминал
-	В терминале выполнить следующие команды: 
    -	cd  .\Client\ 
    -	npm install
    -	npm start
-	Откроется браузер с готовым приложением.
# Важно
    Сервер front части приложения должен открыться на порте 3000, а основной сервер на порте 5001.

# Скриншот внешнего вида приложения
![image](https://user-images.githubusercontent.com/75019623/209459651-27731657-262b-4b30-8382-d1f063ee3e10.png)

