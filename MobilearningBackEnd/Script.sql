CREATE TABLE IF NOT EXISTS "__EFMigrationsHistory" (
    "MigrationId" character varying(150) NOT NULL,
    "ProductVersion" character varying(32) NOT NULL,
    CONSTRAINT "PK___EFMigrationsHistory" PRIMARY KEY ("MigrationId")
);

START TRANSACTION;

CREATE TABLE "Users" (
    "Id" uuid NOT NULL,
    "Name" text NOT NULL,
    "Email" text NOT NULL,
    "Password" text NOT NULL,
    CONSTRAINT "PK_Users" PRIMARY KEY ("Id")
);

CREATE TABLE "Words" (
    "ID" uuid NOT NULL,
    "UserId" uuid NOT NULL,
    "PortugueseWord" text NOT NULL,
    "EnglishWord" text NOT NULL,
    "PortugueseDefinition" text NOT NULL,
    "EnglishDefinition" text NOT NULL,
    CONSTRAINT "PK_Words" PRIMARY KEY ("ID")
);

INSERT INTO "__EFMigrationsHistory" ("MigrationId", "ProductVersion")
VALUES ('20220918141208_InitialCreate', '6.0.8');

COMMIT;

