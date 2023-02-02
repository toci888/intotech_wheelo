package com.wheelo.qrcode;

import org.springframework.boot.SpringApplication;
import org.springframework.boot.autoconfigure.SpringBootApplication;
import org.springframework.boot.builder.SpringApplicationBuilder;
import org.springframework.boot.web.servlet.support.SpringBootServletInitializer;
import org.springframework.web.bind.annotation.RequestMapping;

@SpringBootApplication
public class Wheelo_QRCode extends SpringBootServletInitializer{
	@Override
	protected SpringApplicationBuilder configure(SpringApplicationBuilder builder) {
		return builder.sources(Wheelo_QRCode.class);
	}
	public static void main(String[] args) {
		SpringApplication.run(Wheelo_QRCode.class, args);
	}
	@RequestMapping(value = "/")
	public String hello() {
		return "Hello Wheelo from Tomcat";
	}

}
