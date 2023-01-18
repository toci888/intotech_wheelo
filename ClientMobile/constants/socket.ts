import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

import { endpoints } from "./constants";

export const createSocket = (token: string) => {
    socket = new HubConnectionBuilder()
        .withUrl(endpoints.chat, { accessTokenFactory: () => token })
        .configureLogging(LogLevel.Information)
        .withAutomaticReconnect()
        .build();
}

export let socket: HubConnection;

