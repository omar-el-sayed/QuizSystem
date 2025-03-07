﻿using QuizSystem.Helpers;
using QuizSystem.Models;
using QuizSystem.Repository;
using QuizSystem.ViewModels.Quiz;

namespace QuizSystem.Services.Quizzes
{
    public class QuizService(IGenericRepository<Quiz> _repository) : IQuizService
    {
        public IEnumerable<QuizViewModel> Get(int instructorId)
        {
            return _repository.Get(q => q.InstructorId == instructorId).ToViewModels();
        }

        public void Create(QuizViewModel viewModel, int instructorId)
        {
            var quiz = viewModel.ToModel(instructorId);
            _repository.Add(quiz);
            _repository.SaveChanges();
        }

        public bool Update(int id, QuizViewModel viewModel)
        {
            var quiz = _repository.GetByIdWithTracking(id);
            if (quiz is null)
                return false;

            quiz.StartDate = viewModel.StartDate;
            quiz.TotalGrade = viewModel.TotalGrade;

            _repository.Update(quiz);
            _repository.SaveChanges();
            return true;
        }

        public bool Delete(int id)
        {
            var quiz = _repository.GetByIdWithTracking(id);
            if (quiz is null)
                return false;

            _repository.Delete(quiz);
            _repository.SaveChanges();
            return true;
        }
    }
}
