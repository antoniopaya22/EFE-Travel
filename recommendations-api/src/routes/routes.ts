import { Auth } from '../middlewares/auth';
import { RecommendationsController } from '../controllers/recommmendations-controller';

export class Routes {

    public auth: Auth = new Auth();
    public recommendationsController: RecommendationsController = new RecommendationsController();

    public routes(app): void {

        app.route('/api/recomendaciones/:origen').get(this.recommendationsController.getRecomendaciones)
    }
}
