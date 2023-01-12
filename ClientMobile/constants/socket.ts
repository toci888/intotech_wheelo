import { HubConnectionBuilder, LogLevel } from "@microsoft/signalr";

import { endpoints } from "./constants";

export const socket = new HubConnectionBuilder()
    .withUrl(endpoints.chat
        , { accessTokenFactory: () => "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9uYW1laWRlbnRpZmllciI6ImJhcnRla0BnZy5wbCIsImh0dHA6Ly9zY2hlbWFzLnhtbHNvYXAub3JnL3dzLzIwMDUvMDUvaWRlbnRpdHkvY2xhaW1zL25hbWUiOiJXb2p0ZWsgUnVjaGHFgmEiLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3JvbGUiOiJVc2VyIiwiZXhwIjoxNjczNzI1MjA1LCJpc3MiOiJodHRwOi8vaW50b3RlY2guY29tLnBsIiwiYXVkIjoiaHR0cDovL2ludG90ZWNoLmNvbS5wbCJ9.7mqanxIXejoF01IVxhZKvEvTNi1mEyMknzbE849Ziog" }
    )
    .configureLogging(LogLevel.Information)
    .withAutomaticReconnect()
    .build();

// connect user: session: data=> name, surname, userID, sessionID

// export const makeHubConnection = (accessToken: string): HubConnection => {
//     return new HubConnectionBuilder()
//     .withUrl(endpoints.chat, {
//       // transport: HttpTransportType.WebSockets,
//       accessTokenFactory: () => accessToken,
//       logMessageContent: true
//     })
//     .configureLogging(LogLevel.Information)
//     // .configureLogging({
//     //   log: function (logLevel, message) {
//     //     // TODO: Remove after finish testing
//     //     // console.log('SIGNALR: ' + new Date().toISOString() + ': ' + message)
//     //   }
//     // })
//     .build()
//   }