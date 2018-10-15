export interface Notification {
    id: number;
    userId: number;
    title: string;
    content: string;
    routeLink: string;
    isImportant: boolean;
}