drop schema if exists windmill_inspection_center cascade;
create schema if not exists windmill_inspection_center;

create table windmill_inspection_center.farm(
    id text primary key,
    name text not null
);

create table windmill_inspection_center.turbine(
    id text primary key,
    farm_id text not null references windmill_inspection_center.farm(id),
    name text not null
);

create table windmill_inspection_center.telemetry(
    id text primary key,
    turbine_id text not null references windmill_inspection_center.turbine(id),
    farm_id text not null references windmill_inspection_center.turbine(farm_id),
    timestamp timestamptz not null,

    wind_speed real,
    wind_direction real,
    ambient_temperature real,
    rotor_speed real,
    power_output real,
    nacelle_direction real,
    blade_pitch real,
    generator_temp real,
    gearbox_temp real,
    vibration real,
    status text check (status in ('running', 'stopped'))
);

create index on windmill_inspection_center.telemetry(turbine_id, timestamp desc);

create table windmill_inspection_center.alert(
    id text primary key,
    turbine_id text not null references windmill_inspection_center.turbine(id),
    timestamp timestamptz not null,
    severity text check (severity in ('info', 'warning', 'critical')),
    message text not null
);

create index on windmill_inspection_center.alert(turbine_id, timestamp desc);

create table windmill_inspection_center.operator(
    id text primary key,
    username text not null,
    email text not null,
    password_hash text not null
);

create table windmill_inspection_center.command(
    id text primary key,
    turbine_id text not null references windmill_inspection_center.turbine(id),
    operator_id text not null references windmill_inspection_center.operator(id),
    timestamp timestamptz not null,

    action text not null check (action in ('start', 'stop', 'setInterval', 'setPitch')),
    
    interval_seconds int check (interval_seconds between 1 and 60),
    pitch_angle real check (pitch_angle between -0 and 30),
    reason text
);