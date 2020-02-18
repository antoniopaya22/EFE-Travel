
import { Request, Response } from 'express';
import { VueloRepository } from '../repository/vuelo-repository';


export class VueloController {

    public async getVuelos(req: Request, res: Response) {
        const vuelos = await VueloRepository.getVuelos();
        if (vuelos != undefined) {
            res.status(200).json(vuelos);
        } else {
            res.status(500).json({ error: "Error al obtener los vuelos" })
        }
    }

}
