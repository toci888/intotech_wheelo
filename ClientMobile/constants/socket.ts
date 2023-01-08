import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

import { endpoints } from "./constants";

export const socket = new HubConnectionBuilder()
    .withUrl(endpoints.chat)
    .configureLogging(LogLevel.Information)
    .withAutomaticReconnect()
    .build();
