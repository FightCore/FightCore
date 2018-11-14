import { User } from './../../models/User';
import { FakeUserService } from './fake-user.service';

export abstract class FakeAuthService {
    private static currentUser: User = null;

    public static hasValidAccessToken(): boolean {
        return FakeAuthService.currentUser !== null;
    }

    public static fetchTokenUsingPasswordFlowAndLoadUserProfile(userName: string, password: string): Promise<object> {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                let foundUser: User;
                foundUser = FakeUserService.getUserByName(userName);
                if(foundUser) {
                    FakeAuthService.currentUser = foundUser;
                    resolve();
                }
                else {
                    reject('No Backend: Username not found in current list of users.');
                }
            }, 500);
        });
    }

    public static loadUserProfile(): Promise<object> {
        return new Promise((resolve, reject) => {
            setTimeout(() => {
                if(FakeAuthService.currentUser) {
                    resolve({ username: FakeAuthService.currentUser.userName });
                }
                else {
                    reject('No Backend: No current user found');
                }
            }, 500);
        });
    }

    public static logOut() {
        FakeAuthService.currentUser = null;
    }
}