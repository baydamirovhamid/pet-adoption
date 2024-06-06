CREATE TABLE "customer" (
  "id" integer PRIMARY KEY,
  "name" varchar,
  "surname" varchar,
  "phone" varchar,
  "email" varchar,
  "user_id" integer,
  "birthdate" varchar,
  "created_at" timestamp,
  "created_by" varchar,
  "updated_at" timestamp,
  "updated_by" varchar
);

ALTER TABLE "customer" ADD FOREIGN KEY ("user_id") REFERENCES "user" ("Id");





