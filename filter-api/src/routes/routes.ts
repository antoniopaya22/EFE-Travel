import { UserController } from "../controllers/user-controller";
import { Auth } from '../middlewares/auth';
import { VueloController } from '../controllers/vuelo-controller';

export class Routes {

    public userController: UserController = new UserController();
    public vueloController: VueloController = new VueloController();
    public auth: Auth = new Auth();

    public routes(app): void {

        // ========= USERS =========       
        app.route('/api/users')
            .get(this.userController.getUsers)
            .post(this.userController.addUser)

        app.route('/api/user/:id')
            .get(this.userController.getUserById)
            .delete(this.auth.isAuth, this.userController.deleteUser)

        // ========= VUELOS =========       
        app.route('/api/vuelos')
            .get(this.vueloController.getVuelos)

        // ======== LOGIN ============
        app.route('/login')
            .post(this.auth.login)
    }
}
