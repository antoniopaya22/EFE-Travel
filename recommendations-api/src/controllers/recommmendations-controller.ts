import { Request, Response } from 'express';
import * as soap from 'soap';
import { RecommendationsRepository } from '../repository/recommendations-repository';

export class RecommendationsController {

    public async getRecomendaciones(req: Request, res: Response) {
        var url = process.env.SOAP_API;
        var args = {origin: req.params.origen};
        soap.createClientAsync(url).then((client) => {
            return client.GetRecomendacionesAsync(args);
          }).then((result) => {
            let response = {
                principal: RecommendationsRepository.getRecomendacionPrimaria(result[0]),
                secundaria: RecommendationsRepository.getRecomendacionesSecundarioas(result[0]),
                terciarias: RecommendationsRepository.getRecomendacionesTerciarias(result[0])
            };
            res.status(200).json(response);
        });
    }


}