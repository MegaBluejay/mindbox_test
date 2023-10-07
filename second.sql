-- DDL
create table products (
       id int identity(1, 1) primary key,
       name text not null
);
create table categories (
       id int identity(1, 1) primary key,
       name text not null
);
create table product_categories (
       product_id int not null,
       category_id int not null,
       foreign key (product_id) REFERENCES products(id),
       foreign key (category_id) REFERENCES categories(id),
       primary key (product_id, category_id)
);

-- Example Data
insert into products (name) values ('p1'), ('p2');
insert into categories (name) values ('c1'), ('c2'), ('c3');
insert into product_categories (product_id, category_id) values (1, 1), (1, 2);

-- Query
select p.name, c.name
from products p
left join product_categories pc on p.id=pc.product_id
left join categories c on pc.category_id=c.id;

-- Output
-- p1 | c1
-- p1 | c2
-- p2 | null
