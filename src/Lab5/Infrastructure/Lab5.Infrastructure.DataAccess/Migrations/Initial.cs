using FluentMigrator;
using Itmo.Dev.Platform.Postgres.Migrations;

namespace Lab5.Infrastructure.DataAccess.Migrations;

[Migration(1, "Initial")]
public class Initial : SqlMigration
{
    protected override string GetUpSql(IServiceProvider serviceProvider) =>
        """
        create table admin_password
        (
            password text not null primary key
        );

        insert into admin_password (password) values ('bebra');
        
        create type operation_type as enum
        (
            'deposit',
            'withdraw'
        );
        
        create table bank_account_operations
        (
            bank_account_operations_id bigint primary key generated always as identity,
            bank_account_id bigint not null,
            type operation_type not null,
            amount numeric(10, 2) not null,
            date timestamp not null
        );
        
        create table bank_accounts
        (
            bank_account_id bigint primary key,
            bank_account_pin_code CHAR(4) NOT NULL CHECK (bank_account_pin_code ~ '^[0-9]{4}$'),
            balance numeric(10, 2) not null DEFAULT 0
        );
        
        """;

    protected override string GetDownSql(IServiceProvider serviceProvider) =>
        """
        drop table bank_account_operations
        drop table bank_accounts
        drop table admin_password
        
        drop type operation_type
        """;
}