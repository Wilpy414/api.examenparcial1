PGDMP         )                |            examenparcial1    15.2    15.2                 0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false                       0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false                       0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    16487    examenparcial1    DATABASE     �   CREATE DATABASE examenparcial1 WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Spain.utf8';
    DROP DATABASE examenparcial1;
                postgres    false                        2615    2200    public    SCHEMA        CREATE SCHEMA public;
    DROP SCHEMA public;
                pg_database_owner    false                       0    0    SCHEMA public    COMMENT     6   COMMENT ON SCHEMA public IS 'standard public schema';
                   pg_database_owner    false    4            �            1259    16495    cliente    TABLE     Y  CREATE TABLE public.cliente (
    id bigint NOT NULL,
    id_banco character varying(100),
    nombre character varying(100),
    apellido character varying(100),
    documento character varying(100),
    direccion character varying(100),
    mail character varying(100),
    celular character varying(100),
    estado character varying(100)
);
    DROP TABLE public.cliente;
       public         heap    postgres    false    4            �            1259    16502    factura    TABLE     ,  CREATE TABLE public.factura (
    id bigint NOT NULL,
    id_cliente bigint,
    nro_factura character varying,
    fecha_hora date,
    total bigint,
    total_iva5 bigint,
    total_iva10 bigint,
    total_iva bigint,
    total_letras character varying(100),
    sucursal character varying(100)
);
    DROP TABLE public.factura;
       public         heap    postgres    false    4            �          0    16495    cliente 
   TABLE DATA           n   COPY public.cliente (id, id_banco, nombre, apellido, documento, direccion, mail, celular, estado) FROM stdin;
    public          postgres    false    214   _       �          0    16502    factura 
   TABLE DATA           �   COPY public.factura (id, id_cliente, nro_factura, fecha_hora, total, total_iva5, total_iva10, total_iva, total_letras, sucursal) FROM stdin;
    public          postgres    false    215   �       i           2606    16501    cliente Cliente_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT "Cliente_pkey" PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.cliente DROP CONSTRAINT "Cliente_pkey";
       public            postgres    false    214            k           2606    16508    factura Factura_pkey 
   CONSTRAINT     T   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT "Factura_pkey" PRIMARY KEY (id);
 @   ALTER TABLE ONLY public.factura DROP CONSTRAINT "Factura_pkey";
       public            postgres    false    215            l           1259    16514    fki_factura    INDEX     E   CREATE INDEX fki_factura ON public.factura USING btree (id_cliente);
    DROP INDEX public.fki_factura;
       public            postgres    false    215            m           2606    16509    factura fk_factura    FK CONSTRAINT     �   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT fk_factura FOREIGN KEY (id_cliente) REFERENCES public.cliente(id) NOT VALID;
 <   ALTER TABLE ONLY public.factura DROP CONSTRAINT fk_factura;
       public          postgres    false    3177    215    214            �   �   x�]�A�0���)8aFZ`'�����&��b��eg�;�#�-͊�Xԏ�w�o� ;v)�QY�ɔ��JZ�QWT]K�M�A���DufF��M�ב��מ�I.V�=e��O|F���(�s_�z-�      �   }   x�3�4�400ԅ`SC#N##]]C3NC�4`6�!�X����������^�X����Z��X\���yxs�C`��Y ���Nc0R���W��flpb��O~Qj^U>W� �*�     