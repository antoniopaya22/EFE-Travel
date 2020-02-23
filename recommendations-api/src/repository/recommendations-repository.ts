import { Recomendacion } from "../models/recomendacion";

export class RecommendationsRepository {

    public static getRecomendacionesTerciarias(recos): Recomendacion[] {
        let result = recos.GetRecomendacionesResult.Recommendation;
        let recomendaciones = [];
        if(result.length > 3){
            for (let i = 3; i < result.length; i++) {
                recomendaciones.push(new Recomendacion (result[i].Origin, result[i].Destination, result[i].DepartureDate, result[i].ReturnDate, result[i].Price));
            }
        }
        return recomendaciones;
    }

    public static getRecomendacionesSecundarioas(recos): Recomendacion[] {
        let result = recos.GetRecomendacionesResult.Recommendation;
        let recomendaciones = [];
        if(result.length > 1)
            recomendaciones.push(new Recomendacion (result[1].Origin, result[1].Destination, result[1].DepartureDate, result[1].ReturnDate, result[1].Price));
        if(result.length > 2)
            recomendaciones.push(new Recomendacion (result[2].Origin, result[2].Destination, result[2].DepartureDate, result[2].ReturnDate, result[2].Price));
        return recomendaciones;
    }

    public static getRecomendacionPrimaria(recos): Recomendacion {
        let result = recos.GetRecomendacionesResult.Recommendation[0];
        let rec = new Recomendacion (result.Origin, result.Destination, result.DepartureDate, result.ReturnDate, result.Price);
        return rec;
    }
}