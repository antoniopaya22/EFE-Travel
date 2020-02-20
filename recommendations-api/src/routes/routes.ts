import { Auth } from '../middlewares/auth';
import { Vuelo } from "../models/vuelo";
import { RecommendationsController } from '../controllers/recommmendations-controller';

export class Routes {

    public auth: Auth = new Auth();
    public recommendationsController: RecommendationsController = new RecommendationsController();

    public routes(app): void {

        app.route('/api/testsoap').get(this.recommendationsController.testSOAP)
        app.route('/api/getvuelos').get(this.recommendationsController.getVuelos)
        // ========= VUELOS =========       
        app.route('/api/vuelos')
            .get(this.auth.isAuth, (req, res) => {
                res.status(200).json([
                    new Vuelo('Asturias', 'Madrid', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 1390.00, 'Iberia', 'enlace'),
                    new Vuelo('Asturias', 'Barcelona', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 1290.00, 'Vueling', 'enlace'),
                    new Vuelo('Asturias', 'Malaga', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 890.00, 'Ryanair', 'enlace')
                ]);
            })
    }
}
