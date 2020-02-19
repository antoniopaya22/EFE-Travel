import { UserController } from "../controllers/user-controller";
import { Auth } from '../middlewares/auth';
import { Vuelo } from "../models/vuelo";

export class Routes {

    public userController: UserController = new UserController();
    public auth: Auth = new Auth();

    public routes(app): void {

        // ========= USERS =========       
        app.route('/api/users')
            .get(this.auth.isAuth, this.userController.getUsers)
            .post(this.userController.addUser)

        app.route('/api/user/:id')
            .get(this.auth.isAuth, this.userController.getUserById)
            .delete(this.auth.isAuth, this.userController.deleteUser)

        // ========= VUELOS =========       
        app.route('/api/vuelos')
            .get((req, res) => {
                res.status(200).json([
                    new Vuelo('Asturias', 'Madrid', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 1390.00, 'Iberia', 'enlace'),
                    new Vuelo('Asturias', 'Barcelona', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 1290.00, 'Vueling', 'enlace'),
                    new Vuelo('Asturias', 'Malaga', '2020-08-01T10:00:00', '2020-08-01T16:20:00', 2, 890.00, 'Ryanair', 'enlace')
                ]);
            })

        // ======== LOGIN ============
        app.route('/login')
            .post(this.auth.login)

        app.route('/verify-token')
            .get(this.auth.checkToken)
    }
}
