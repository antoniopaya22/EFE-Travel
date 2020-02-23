export class Recomendacion {

    constructor(
        public origen?: string,
        public destino?: string,
        public fecha_salida?: string,
        public fecha_llegada?: string,
        public precio?: number
    ) {
        this.origen = origen;
        this.destino = destino;
        this.fecha_salida = fecha_salida;
        this.fecha_llegada = fecha_llegada;
        this.precio = precio;
    }

}