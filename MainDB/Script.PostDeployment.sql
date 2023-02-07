if not EXISTS (SELECT 1 from dbo.[User])
BEGIN
    insert into dbo.[User] (Name, Email, Password, Role)
    values
    ('Marius', 'Marius', 'Marius', 'ADMIN'),
    ('John', 'Cena', 'BOOM', 'USER'),
    ('WoW','ITS','JOHN', 'USER')
END
