import { Notification } from './Notification';

export interface NotificationsResponse {
    totalNotifications: number;
    currentPage: number;
    notifications: Notification[];
}