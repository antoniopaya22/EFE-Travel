import { User } from '../models/user';
import { getConnection, DeleteResult } from "typeorm";

export class UserRepository {

    public static getUsers(): Promise<User[]> {
        return getConnection().getRepository(User).find();
    }

    public static getUserById(id: number): Promise<User> {
        return getConnection().getRepository(User).findOne({
            where: {
                id: id
            }
        });
    }

    public static getUserByUsername(username: number): Promise<User> {
        return getConnection().getRepository(User).findOne({
            where: {
                username: username
            }
        });
    }

    public static deleteUser(id: number): Promise<DeleteResult> {
        return getConnection().getRepository(User).delete({id: id});
    }

    public static addUser(user: User): Promise<User> {
        return getConnection().getRepository(User).save(user);
    }
}