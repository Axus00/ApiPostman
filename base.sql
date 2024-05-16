CREATE TABLE Users(
    id int auto_increment,
    Names varchar(45),
    LastNames varchar(45),
    Email varchar(45),
    PRIMARY KEY (id)
);

INSERT INTO Users (Names, LastNames, Email) VALUES ('Willmar', 'Jaramillo', 'correo@correo.com'),
('Fernando', 'Gómez', 'fernando@gmail.com'),('Fernanda', 'Saravia', 'fernanda@gmail.com');

select * from Users;