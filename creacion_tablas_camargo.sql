CREATE TABLE "estado" (
	"id_estado" int constraint pk_estado primary key,
	"nombre" varchar
);

create table "municipio"(
	"id_municipio" serial constraint pk_municipio primary key,
 	"nombre" varchar not null,
 	"id_estado" int not null REFERENCES estado (id_estado)
);

CREATE TABLE "orden_compra" (
  	"id_orden_compra" SERIAL PRIMARY key,
  	"direccion" varchar
);

CREATE TABLE "cotizacion" (
	"id_cotizacion" SERIAL PRIMARY KEY,
	"direccion" varchar
);

create table "empresa_cliente"(
	"id_empresa_cliente" serial primary key,
	"nombre" varchar
);
insert into empresa_cliente (nombre) values ('Otro');

CREATE TABLE "contacto" (
	"id_contacto" SERIAL PRIMARY KEY,
	"nombre" varchar,
	"telefono" varchar,
	"correo" varchar,
	"id_empresa_cliente" int not null REFERENCES empresa_cliente (id_empresa_cliente)
);
insert into contacto (nombre, telefono, correo, id_empresa_cliente) values ('Otro', '-', '-', 1);

CREATE TABLE "empresa" (
	"id_empresa" SERIAL PRIMARY KEY,
	"nombre" varchar
);
insert into empresa (nombre) values ('EPYESA');
insert into empresa (nombre) values ('PGS');


CREATE TABLE "personal" (
	"id_personal" SERIAL PRIMARY KEY,
	"nombre" varchar
);
insert into "personal" (nombre) values ('Angelica Daniela Escudero Rivera');
insert into "personal" (nombre) values ('Benjamín Silva Zarate');
insert into "personal" (nombre) values ('Blanca Carolina García Curiel');
insert into "personal" (nombre) values ('María De Los Ángeles Pérez Camargo');
insert into "personal" (nombre) values ('Teófilo Galeana Pacheco');
insert into "personal" (nombre) values ('Itzel Iridian Zamora Islas');
insert into "personal" (nombre) values ('Otro');




CREATE TABLE "proyecto" (
	"id_proyecto" serial constraint pk_proyecto primary key,
	"ID" varchar,
	"DateCreated" timestamp DEFAULT(now()),
	"nombre" varchar not null,
  	"fecha" date not null,
  	"subcontratacion" boolean,
  	"factura" boolean,
  	"monto_factura" float,
  	"latitud" real,
  	"longitud" real,
	"num_sondeos" int,
	"cantidad_pca" int,
	"prof_max_metros" real,
	"terminado" boolean default 'false',
	"fecha_finalizacion" date,
	"id_municipio" int not null REFERENCES municipio (id_municipio),
	"id_empresa" int REFERENCES empresa (id_empresa),
	"id_contacto" int REFERENCES contacto (id_contacto)
);

CREATE TABLE personal_proyecto (
	"id_proyecto" int references proyecto (id_proyecto) ON UPDATE CASCADE ON DELETE CASCADE,
	"id_personal" int references personal (id_personal) ON UPDATE cascade,
	constraint pk_personal_proyecto primary key (id_proyecto, id_personal),
	fecha date
);

CREATE TABLE "vehiculo" (
	"id_vehiculo" SERIAL PRIMARY KEY,
	"marca" varchar,
	"modelo" varchar,
	"numero" int
);

CREATE TABLE vehiculo_proyecto (
	"id_proyecto" int references proyecto (id_proyecto) ON UPDATE CASCADE ON DELETE CASCADE,
	"id_vehiculo" int references vehiculo (id_vehiculo) ON UPDATE cascade,
	constraint pk_vehiculo_proyecto primary key (id_proyecto, id_vehiculo),
	fecha date
);

CREATE TABLE "gasto" (
	"id_gasto" SERIAL PRIMARY KEY,
	"monto" real,
	"tipo" varchar,
	"id_proyecto" int
);

CREATE TABLE "usuario-contrasena"(
	"id_usuario_contrasena" serial PRIMARY KEY,
	"usuario" varchar,
	"contrasena" varchar
);

insert into "usuario-contrasena" (usuario, contrasena) values ('visitante', 'visitante');
insert into "usuario-contrasena" (usuario, contrasena) values ('administrador', 'admin12345');

create view id_propio_proyecto as (
	select id_proyecto, extract(year from fecha)  as "id anio", 
	ROW_NUMBER() OVER (PARTITION BY extract(year from fecha) ORDER BY id_proyecto) as "id numero"
	from proyecto p--esto es si los proyectos se meten en el orden que siguen
);


create view id_formato as (
	SELECT CASE WHEN (ipp."id numero" < 10)  THEN concat(ipp."id anio",'-00',ipp."id numero")
			WHEN ipp."id numero" >= 10 and ipp."id numero" < 100   THEN concat(ipp."id anio",'-0',ipp."id numero")
                             ELSE concat(ipp."id anio",'-',ipp."id numero")
       END AS "ID",
       ipp.id_proyecto 
FROM id_propio_proyecto ipp
);

create view reporte_facturas as (
	select p."ID", p.nombre as "Proyecto", e.nombre as "Empresa",
	p.factura, p.monto_factura, 
	case when (factura = 'true') then cast((p.monto_factura + (p.monto_factura*0.16)) as varchar)
	else 'No aplica'
	end as "monto_IVA"
	from proyecto p
	join empresa e using (id_empresa)
	order by p."ID"
	
);



with aux as (select p.id_proyecto, p."ID", p.nombre
from proyecto p) 
update proyecto set prof_max_metros = 55 
where id_proyecto = (select id_proyecto from aux where aux."ID" = '2021-1' and nombre = 'c') ;
			

