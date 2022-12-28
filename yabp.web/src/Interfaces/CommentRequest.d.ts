export interface CommentRequest {
  content: string
  authorId: number
  postId: number
  parentId?: number
};
