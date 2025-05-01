IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
CREATE TABLE [Teams] (
    [Id] int NOT NULL IDENTITY,
    [Name] nvarchar(max) NOT NULL,
    [ShortName] nvarchar(max) NOT NULL,
    [Trophies] int NOT NULL,
    [FanBaseType] int NOT NULL,
    CONSTRAINT [PK_Teams] PRIMARY KEY ([Id])
);

CREATE TABLE [Players] (
    [Id] int NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [JerseyNumber] int NOT NULL,
    [TotalRunsScored] int NOT NULL,
    [TeamId] int NOT NULL,
    CONSTRAINT [PK_Players] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Players_Teams_TeamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([Id]) ON DELETE CASCADE
);

CREATE INDEX [IX_Players_TeamId] ON [Players] ([TeamId]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250426113235_initial table crate', N'9.0.4');

EXEC sp_rename N'[Teams].[Trophies]', N'Total trophies', 'COLUMN';

EXEC sp_rename N'[Players].[TotalRunsScored]', N'TotalRuns', 'COLUMN';

EXEC sp_rename N'[Players].[JerseyNumber]', N'ShirtNumber', 'COLUMN';

DECLARE @defaultSchema AS sysname;
SET @defaultSchema = SCHEMA_NAME();
DECLARE @description AS sql_variant;
SET @description = N'Teams Data Table';
EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teams';

DECLARE @defaultSchema1 AS sysname;
SET @defaultSchema1 = SCHEMA_NAME();
DECLARE @description1 AS sql_variant;
SET @description1 = N'Players table';
EXEC sp_addextendedproperty 'MS_Description', @description1, 'SCHEMA', @defaultSchema1, 'TABLE', N'Players';

DECLARE @var2 sysname;
SELECT @var2 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Teams]') AND [c].[name] = N'ShortName');
IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Teams] DROP CONSTRAINT [' + @var2 + '];');
ALTER TABLE [Teams] ALTER COLUMN [ShortName] nvarchar(10) NOT NULL;

DECLARE @var3 sysname;
SELECT @var3 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Teams]') AND [c].[name] = N'Name');
IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Teams] DROP CONSTRAINT [' + @var3 + '];');
ALTER TABLE [Teams] ALTER COLUMN [Name] nvarchar(50) NOT NULL;

DECLARE @var4 sysname;
SELECT @var4 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Teams]') AND [c].[name] = N'FanBaseType');
IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [Teams] DROP CONSTRAINT [' + @var4 + '];');
ALTER TABLE [Teams] ADD DEFAULT 3 FOR [FanBaseType];

DECLARE @var5 sysname;
SELECT @var5 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Teams]') AND [c].[name] = N'Total trophies');
IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [Teams] DROP CONSTRAINT [' + @var5 + '];');
ALTER TABLE [Teams] ALTER COLUMN [Total trophies] int NULL;

DECLARE @var6 sysname;
SELECT @var6 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Players]') AND [c].[name] = N'LastName');
IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [Players] DROP CONSTRAINT [' + @var6 + '];');
ALTER TABLE [Players] ALTER COLUMN [LastName] nvarchar(50) NOT NULL;
ALTER TABLE [Players] ADD DEFAULT N'LastName' FOR [LastName];

DECLARE @var7 sysname;
SELECT @var7 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Players]') AND [c].[name] = N'FirstName');
IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [Players] DROP CONSTRAINT [' + @var7 + '];');
ALTER TABLE [Players] ALTER COLUMN [FirstName] nvarchar(50) NOT NULL;
ALTER TABLE [Players] ADD DEFAULT N'FirstName' FOR [FirstName];

DECLARE @var8 sysname;
SELECT @var8 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Players]') AND [c].[name] = N'TotalRuns');
IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [Players] DROP CONSTRAINT [' + @var8 + '];');
ALTER TABLE [Players] ADD DEFAULT 0 FOR [TotalRuns];

DECLARE @var9 sysname;
SELECT @var9 = [d].[name]
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Players]') AND [c].[name] = N'ShirtNumber');
IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [Players] DROP CONSTRAINT [' + @var9 + '];');
ALTER TABLE [Players] ADD DEFAULT 0 FOR [ShirtNumber];

ALTER TABLE [Teams] ADD [FancyName] AS CONCAT(ShortName, ' : ', Name);

ALTER TABLE [Teams] ADD CONSTRAINT [AK_Teams_Name] UNIQUE ([Name]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250427122500_fluent-api', N'9.0.4');

ALTER TABLE [Players] DROP CONSTRAINT [FK_Players_Teams_TeamId];

CREATE UNIQUE INDEX [IX_Teams_Name] ON [Teams] ([Name]);

CREATE NONCLUSTERED INDEX [IX_Players_name] ON [Players] ([FirstName], [LastName]);

ALTER TABLE [Players] ADD CONSTRAINT [FK_Playey_Team_teamId] FOREIGN KEY ([TeamId]) REFERENCES [Teams] ([Id]);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20250430024004_name-changes', N'9.0.4');

COMMIT;
GO

