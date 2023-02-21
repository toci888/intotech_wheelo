import { HubConnection, HubConnectionBuilder, LogLevel } from "@microsoft/signalr";
import { Author } from "../types/conversation";

import { endpoints } from "./constants";

export const createSocket = (token: string) => {
    socket = new HubConnectionBuilder()
        .withUrl(endpoints.chat, { accessTokenFactory: () => token })
        .configureLogging(LogLevel.Information)
        .withAutomaticReconnect()
        .build();
}

export let socket: HubConnection;

export const connectUser = async (id: number) => {
    return await socket.invoke("connectUser", id);
}

export const sendMessage = async (
    idAccount: number,
    roomId: string,
    text: string,
  ) => {
    return await socket.invoke("sendMessage", {
        idAccount,
        roomId,
        text,
    });
}

export const joinRoom = async (roomId: string) => {
    return await socket.invoke("joinRoom", roomId);
}

export const createRoom = async (userId: number, accountIds: number[]) => {
    return await socket.invoke("createRoom", userId, accountIds);
}
