import { getConnection, DeleteResult } from "typeorm";
import { Vuelo } from "../models/vuelo";

export class VueloRepository {

    public static getVuelos(): Vuelo[] {
        return [
            new Vuelo('Asturias', 'Madrid', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 1390.00, 'Iberia', 'enlace'),
            new Vuelo('Asturias', 'Barcelona', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 1290.00, 'Vueling', 'enlace'),
            new Vuelo('Asturias', 'Malaga', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 890.00, 'Ryanair', 'enlace')
        ];
    }

}