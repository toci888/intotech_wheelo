import { HubConnectionBuilder, LogLevel } from '@microsoft/signalr';

export default class WheeloChatEngine {

    constructor(receiveMsgCall) {

        this.receiveMessageCall = receiveMsgCall;
    }

    connection;
    messages = [];
    room;
    receiveMessageCall;

    serverUrl = "https://localhost:7082/wheeloChat";
    ReceiveMessageCallback = "ReceiveMessage";
    joinRoomCallback = "JoinRoomFuck";
    sendMessageCallback = "SendMessage";

    joinRoomClient = async (room) => {

        this.room = room;

        this.connection = new HubConnectionBuilder()
            .withUrl(this.serverUrl)
            .configureLogging(LogLevel.Information)
            .build();

        this.connection.on(this.ReceiveMessageCallback, (user, message) => {
            
            this.receiveMessageCall(user, message);
            this.messages = [...this.messages, { user, message }];
        });

        this.connection.onclose(e => {
            this.connection = null;
        });

        try{
            console.log('1 str conn start', this.room); 
        await this.connection.start();
        console.log('2 conn start', this.room);

        await this.connection.invoke(this.joinRoomCallback, this.room);

        console.log('3 join room', this.room);

}catch (e) {
    console.log(e);
  }
        console.log('end of join room');
        //setConnection(connection);
    }

    sendMessage = async (message, user) => {
        try {
          //console.log(message, user, connection, room);
          await this.connection.invoke(this.sendMessageCallback, message, user, this.room);

        } catch (e) {
          console.log(e);
        }
      }
}