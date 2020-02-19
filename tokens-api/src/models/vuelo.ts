import { Entity, Column, PrimaryGeneratedColumn } from "typeorm";

@Entity()
export class Vuelo {

    constructor(
        origen?: string,
        destino?: string,
        fecha_salida?: string,
        fecha_llegada?: string,
        personas?: number,
        precio?: number,
        aerolinea?: string,
        enlace?: string
    ) {
        this.origen = origen;
        this.destino = destino;
        this.fecha_salida = fecha_salida;
        this.fecha_llegada = fecha_llegada;
        this.personas = personas;
        this.precio = precio;
        this.aerolinea = aerolinea;
        this.enlace = enlace;
    }

    @PrimaryGeneratedColumn()
    id: number;

    @Column()
    origen: string;

    @Column()
    destino: string;

    @Column()
    fecha_salida: string;

    @Column()
    fecha_llegada: string;

    @Column()
    personas: number;

    @Column()
    precio: number;

    @Column()
    aerolinea: string;

    @Column()
    enlace: string;

}