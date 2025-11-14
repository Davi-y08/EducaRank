package main

import (
  "net/http"

  "github.com/gin-gonic/gin"
)

func main(){

	// criar rota do gin com o middleware padrão
	r := gin.Default()

	r.GET("/ping", func (c *gin.Context)  {
		// retornar reposta JSON
		c.JSON(http.StatusOK, gin.H{
			"message": "pong",
		})
	})

	r.Run()
}