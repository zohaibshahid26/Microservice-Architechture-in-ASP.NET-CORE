# Microservice Architechture using ASP.NET CORE WEB API

## Software Architechture and Design Assignment 4

### Group-Members:

- BSEF21M001 Yeshal Khan
- BSEF21M008 Zohaib Shahid
- BSEF21M009 Abdullah Malick

## Description

This project is a Web API built using ASP.NET Core for managing blog posts. It allows users to perform CRUD operations (Create, Read, Update, Delete) on blog posts. The API is designed following the microservice architecture principles.

## Endpoints

- **GET /api/BlogPosts**  
  Retrieves a list of all blog posts.

- **GET /api/BlogPosts/{id}**  
  Retrieves a specific blog post by its ID.

- **POST /api/BlogPosts**  
  Creates a new blog post.  
  Request body should be in JSON format:
  ```json
  {
      "title": "New Blog Post",
      "content": "This is the content of the new blog post.",
      "author": "John Doe",
      "createdAt": "2024-06-16T15:24:39.636Z",
      "categoryId": 1
  }
- **PUT /api/BlogPosts**  
  Updates blog post.  
  Request body should be in JSON format:
  ```json
  {
      "title": "Updated Blog Post",
      "content": "This is the content of the updated blog post.",
      "author": "John Doe",
      "createdAt": "2024-06-16T15:24:39.636Z",
      "categoryId": 1
  }
  
- **DELETE /api/BlogPosts/{id}**  
 Delete a specific blog post by its ID.
