import { User } from "src/app/models/User";

export abstract class FakeUserService {
    private static knownUsers: User[] = [
        { id: 1, email: 'no@no.com', userName: 'TestUserA' },
        { id: 2, email: 'dadada@da.com', userName: 'TestUserB' }
    ];

    public static getUser(id: number): User {
        return FakeUserService.knownUsers.find(user => user.id === id);
    }

    public static getUserByName(userName: string): User {
        return FakeUserService.knownUsers.find(user => user.userName === userName);
    }
}